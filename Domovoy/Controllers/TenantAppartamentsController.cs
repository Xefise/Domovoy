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
    
    [HttpPut("{id}")]
    public async Task<ActionResult<ApartmentViewModel>> PutApartament(int id, ApartmentPutTenant apartment)
    {
        var entity = _db.Apartments
            .Include(a => a.Tenants)
            .Include(a => a.TenantsWhoMainThis)
            .Include(a => a.Owner)
            .Include(a => a.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany)
            .FirstOrDefault(a => a.Id == id && a.Owner.Id == HttpContext.GetUser().Id);
 
        if (entity == null)
        {
            return NotFound();
        }

        if (entity.Id != apartment.Id)
        {
            return BadRequest();
        }

        _mapper.Map(apartment, entity);

        _db.SaveChangesAsync();
    
        return Ok(_mapper.Map<ApartmentViewModel>(entity));
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