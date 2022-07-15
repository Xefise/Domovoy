using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domovoy.Controllers;

[Authorize("Tenant")]
[Route("api/[controller]")]
[ApiController]
public class TenantAppartamentsController: ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public TenantAppartamentsController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ApartmentViewModel>>> MyApartaments()
    {
        return await _mapper.ProjectTo<ApartmentViewModel>(_db.Apartments.Where(a => a.Tenants.Contains(HttpContext.GetUser()))).ToListAsync();
    }

    [HttpPost("join")]
    public async Task<ActionResult> JoinByCode(string code)
    {
        var codeEntity = await _db.InviteCodes
            .Include(i => i.Apartment)
            .Include(i => i.Apartment.Tenants)
            .Include(i => i.Apartment.Owner)
            .FirstOrDefaultAsync(c => c.Code == code);

        if (codeEntity == null)
        {
            await Task.Delay(1000); // Защита от перебора
            return BadRequest();
        }

        if (codeEntity.Apartment.Tenants.Count() == 0) codeEntity.Apartment.Owner = HttpContext.GetUser();
        codeEntity.Apartment.Tenants.Add(HttpContext.GetUser());
        _db.InviteCodes.Remove(codeEntity);

        await _db.SaveChangesAsync();
        
        return Ok();
    }
}