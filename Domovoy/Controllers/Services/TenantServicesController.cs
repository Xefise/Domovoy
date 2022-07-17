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
public class TenantServicesController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public TenantServicesController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet("{apartmentId}")]
    public async Task<ActionResult<ServicesCollection>> GetServices(int? apartmentId)
    {
        var apartment = await _db.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId);

        return new ServicesCollection()
        {
            ApartmentServices = apartment != null
                ? await _db.ApartmentServices.Where(s =>
                        s.ScopeHouses
                            .SelectMany(h => h.HouseEntrances)
                            .SelectMany(e => e.Apartments)
                            .Contains(apartment))
                    .ToListAsync()
                : new List<ApartmentService>(),
            InformerServices = apartment != null
                ? await _db.InformerServices.Where(s =>
                        s.ScopeHouses
                            .SelectMany(h => h.HouseEntrances)
                            .SelectMany(e => e.Apartments)
                            .Contains(apartment))
                    .ToListAsync()
                : new List<InformerService>(),
            UserServices = await _db.UserServices.ToListAsync()
        };
    }

    [HttpPost("request/apartment/{apartmentId}/{serviceId}")]
    public async Task<ActionResult> RequestApartmentService(int apartmentId, int serviceId, string data)
    {
        var service = await _db.ApartmentServices.FirstOrDefaultAsync(s => s.Id == serviceId);
        if (service == null) return BadRequest();
        
        var apartment = await _db.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId);
        if (apartmentId == null) return BadRequest();

        var newEntry = new ServiceEntry<ApartmentService>()
        {
            Apartment = apartment,
            Completed = false,
            Data = data,
            Service = service,
            User = HttpContext.GetUser()
        };

        _db.ApartmentServiceEntries.Add(newEntry);

        await _db.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpPost("request/informer/{apartmentId}/{serviceId}")]
    public async Task<ActionResult> RequestInformerService(int apartmentId, int serviceId, string data)
    {
        var service = await _db.InformerServices.FirstOrDefaultAsync(s => s.Id == serviceId);
        if (service == null) return BadRequest();
        
        var apartment = await _db.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId);
        if (apartmentId == null) return BadRequest();

        var newEntry = new ServiceEntry<InformerService>()
        {
            Apartment = apartment,
            Completed = false,
            Data = data,
            Service = service,
            User = HttpContext.GetUser()
        };

        _db.InformerServiceEntries.Add(newEntry);

        await _db.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpPost("request/user/{serviceId}")]
    public async Task<ActionResult> RequestUserService(int serviceId, string data)
    {
        var service = await _db.UserServices.FirstOrDefaultAsync(s => s.Id == serviceId);
        if (service == null) return BadRequest();

        var newEntry = new ServiceEntry<UserService>()
        {
            Completed = false,
            Data = data,
            Service = service,
            User = HttpContext.GetUser()
        };

        _db.UserServiceEntries.Add(newEntry);

        await _db.SaveChangesAsync();
        
        return Ok();
    }
}