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
}