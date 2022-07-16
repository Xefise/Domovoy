using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApartmentState = Domovoy.Models.ApartmentState;

namespace Domovoy.Controllers;

[Authorize("Tenant")]
[Route("api/[controller]")]
[ApiController]
public class TenantRequestsController: ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public TenantRequestsController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    [HttpPost("{apartmentId}")]
    public async Task<ActionResult> Request(int apartmentId, string additional)
    {
        var apartment = await _db.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId && (a.ApartmentState == ApartmentState.ForRent || a.ApartmentState == ApartmentState.ForSell)); 
        if (apartment == null) return BadRequest();

        var newRequest = new ApartmentRequest()
        {
            Apartment = apartment,
            Requester = HttpContext.GetUser(),
            AdditionalContacts = additional
        };
        
        _db.ApartmentRequests.Add(newRequest);

        await _db.SaveChangesAsync();

        return Ok();
    }
}