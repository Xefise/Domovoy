using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApartmentState = Domovoy.Models.ApartmentState;

namespace Domovoy.Controllers;

[Authorize("Agent")]
[Route("api/[controller]")]
[ApiController]
public class AgentRequestsController: ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public AgentRequestsController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ApartmentRequestDTO>>> GetRequests()
    {
        return await _mapper.ProjectTo<ApartmentRequestDTO>(
            _db.ApartmentRequests
                .Include(r => r.Requester)
                .Include(r => r.Apartment.Owner)
                .Include(r => r.Apartment.Tenants)
                .Include(r => r.Apartment.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany)
        ).ToListAsync();
    }
    
    [HttpPost("accept/{requestId}")]
    public async Task<ActionResult> AcceptRequest(int requestId)
    {
        var request = await _db.ApartmentRequests
            .Include(r => r.Requester)
            .Include(r => r.Apartment.Owner)
            .Include(r => r.Apartment.Tenants)
            .Include(r => r.Apartment.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany)
            .FirstOrDefaultAsync(r => r.Id == requestId);

        if (request == null) return BadRequest();

        if (request.Apartment.ApartmentState == ApartmentState.ForSell) request.Apartment.Owner = request.Requester;
        if (request.Apartment.ApartmentState == ApartmentState.ForRent) request.Apartment.Tenants.Add(request.Requester);

        _db.ApartmentRequests.Remove(request);

        request.Apartment.ApartmentState = ApartmentState.NotForSell;

        await _db.SaveChangesAsync();

        return Ok();
    }
    
    [HttpPost("deny/{requestId}")]
    public async Task<ActionResult> DenyRequest(int requestId)
    {
        var request = await _db.ApartmentRequests
            .FirstOrDefaultAsync(r => r.Id == requestId);
        
        if (request == null) return BadRequest();
        
        _db.ApartmentRequests.Remove(request);

        await _db.SaveChangesAsync();

        return Ok();
    }
}