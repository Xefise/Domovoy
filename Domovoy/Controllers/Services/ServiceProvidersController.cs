using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domovoy.Controllers;


[Authorize("ServiceProvider")]
[Route("api/[controller]")]
[ApiController]
public class ServiceProvidersController: ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ServiceProvidersController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    [HttpGet("entries")]
    public async Task<ActionResult<ServiceEntriesCollection>> GetServicesEntries()
    {
        return new ServiceEntriesCollection()
        {
            ApartmentServicesEntries = await _mapper.ProjectTo<ServiceEntryDTO<ApartmentService>>(_db.ApartmentServiceEntries.Where(s => s.Service.SerivceProvider.Id == HttpContext.GetUser().Id)).ToListAsync(),
            InformerServicesEntries = await _mapper.ProjectTo<ServiceEntryDTO<InformerService>>(_db.InformerServiceEntries.Where(s => s.Service.SerivceProvider.Id == HttpContext.GetUser().Id)).ToListAsync(),
            UserServicesEntries = await _mapper.ProjectTo<ServiceEntryDTO<UserService>>(_db.UserServiceEntries.Where(s => s.Service.SerivceProvider.Id == HttpContext.GetUser().Id)).ToListAsync(),
        };
    }
    
    [HttpGet("complete/{entryId}")]
    public async Task<ActionResult> CompleateEntry(int entryId, [FromQuery] ServiceType type)
    {
        switch (type)
        {
            case ServiceType.Apartment:
                var apartmentEntry =  await _db.ApartmentServiceEntries.FirstOrDefaultAsync(s => s.Id == entryId);
                if (apartmentEntry == null) return BadRequest();

                apartmentEntry.Completed = true;
                break;
            case ServiceType.Infrormer:
                var informerEntry =  await _db.InformerServiceEntries.FirstOrDefaultAsync(s => s.Id == entryId);
                if (informerEntry == null) return BadRequest();

                informerEntry.Completed = true;
                break;
            case ServiceType.User:
                var userEntry =  await _db.UserServiceEntries.FirstOrDefaultAsync(s => s.Id == entryId);
                if (userEntry == null) return BadRequest();

                userEntry.Completed = true;
                break;
        };

        await _db.SaveChangesAsync();

        return Ok();
    }
}

public enum ServiceType
{
    Apartment,
    User,
    Infrormer
}