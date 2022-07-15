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
public class TenantCartController: ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public TenantCartController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ApartmentViewModel>>> GetCart()
    {
        return await _mapper.ProjectTo<ApartmentViewModel>(_db.Apartments.Where(a => a.TenantsWhoAddThisToCart.Contains(HttpContext.GetUser()))).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> AddToCart(int apartmentId)
    {
        var apartment = await _db.Apartments.Include(a => a.TenantsWhoAddThisToCart).FirstAsync(a => a.Id == apartmentId);
        if (apartment == null) return BadRequest();
        
        apartment.TenantsWhoAddThisToCart.Add(HttpContext.GetUser());

        await _db.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpDelete]
    public async Task<ActionResult> RemoveFromCart(int apartmentId)
    {
        var apartment = await _db.Apartments.Include(a => a.TenantsWhoAddThisToCart).FirstAsync(a => a.Id == apartmentId);
        if (apartment == null) return BadRequest();
        
        apartment.TenantsWhoAddThisToCart.Remove(HttpContext.GetUser());

        await _db.SaveChangesAsync();
        
        return Ok();
    }
}