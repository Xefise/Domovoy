using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domovoy.Controllers;

[Authorize("Tenant")]
[Route("api/[controller]")]
[ApiController]
public class AppartamentsController: ControllerBase
{
    private readonly ApplicationDbContext _db;
    public AppartamentsController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Apartment>>> MyApartaments()
    {
        return await _db.Apartments.Where(a => a.Tenants.Contains(HttpContext.GetUser())).ToListAsync();
    }
}