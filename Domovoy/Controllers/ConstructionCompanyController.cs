using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domovoy.Controllers;

[Authorize("Employee")]
[Route("api/[controller]")]
[ApiController]
public class ConstructionCompanyController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ConstructionCompanyController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ConstructionCompanyDetails>> GetCompany()
    {
        return _mapper.Map<ConstructionCompanyDetails>(await _db.ConstructionCompanies
            .Include("ResidentialComplexes.ApartmentHouses")
            .FirstAsync(c => c.Employees.Contains(HttpContext.GetUser())));
    }

    [HttpGet("houses/{id}")]
    public async Task<ActionResult<List<HouseEntranceDetails>>> GetApartaments(int id, [FromQuery] string? search)
    {
        return _mapper.Map<List<HouseEntranceDetails>>(
            _db.HouseEntrances
                .Include("Apartments.InviteCodes")
                .Include("Apartments.SmartHomeDevices")
                .Where(e =>
                    e.ApartmentHouse.ResidentialComplex.Id == id &&
                    e.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser()))
                .Select(b => new
                {
                    b,
                    Apartments = b.Apartments.Where(a =>
                        search != null ? a.ApartmentNumber.ToString().Contains(search) : true)
                })
                .AsEnumerable()
                .Select(x => x.b)
                .ToList()
        );
    }

    [HttpPost("complexes")]
    public async Task<ActionResult> CreateResidentialComplex(ResidentialComplexCreate residentialComplexCreate)
    {
        var complex = _mapper.Map<ResidentialComplex>(residentialComplexCreate);
        complex.ConstructionCompany =
            await _db.ConstructionCompanies.FirstAsync(c => c.Employees.Contains(HttpContext.GetUser()));
        _db.ResidentialComplexes.Add(complex);
        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("complexes/{id}")]
    public async Task<ActionResult> DeleteComplex(int id)
    {
        _db.ResidentialComplexes.RemoveRange(_db.ResidentialComplexes.Where(c =>
            c.Id == id && c.ConstructionCompany.Employees.Contains(HttpContext.GetUser())));

        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("houses")]
    public async Task<ActionResult> CreateApartmentHouse(ApartmentHouseCreate apartmentHouseCreate)
    {
        var house = _mapper.Map<ApartmentHouse>(apartmentHouseCreate);

        if (_db.ResidentialComplexes
                .Where(c =>
                    c.ConstructionCompany.Employees.Contains(HttpContext.GetUser()) &&
                    c.Id == house.ResidentialComplexId)
                .Count() == 0)
            return BadRequest();

        _db.ApartmentHouses.Add(house);
        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("houses/{id}")]
    public async Task<ActionResult> DeleteHouse(int id)
    {
        _db.ApartmentHouses.RemoveRange(_db.ApartmentHouses.Where(c =>
            c.Id == id && c.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser())));

        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("entrances")]
    public async Task<ActionResult> CreateEntrance(HouseEntranceCreate houseEntranceCreate)
    {
        var entrance = _mapper.Map<HouseEntrance>(houseEntranceCreate);

        if (_db.ApartmentHouses
                .Where(c =>
                    c.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser()) &&
                    c.Id == entrance.ApartmentHouseId)
                .Count() == 0)
            return BadRequest();

        _db.HouseEntrances.Add(entrance);
        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("entrances/{id}")]
    public async Task<ActionResult> DeleteEntrance(int id)
    {
        _db.HouseEntrances.RemoveRange(_db.HouseEntrances.Where(c =>
            c.Id == id &&
            c.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser())));

        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("apartments")]
    public async Task<ActionResult> CreateApartament(ApartmentCreate houseEntranceCreate)
    {
        var apartment = _mapper.Map<Apartment>(houseEntranceCreate);

        if (_db.HouseEntrances
                .Where(c =>
                    c.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser()) &&
                    c.Id == apartment.HouseEntranceId)
                .Count() == 0)
            return BadRequest();

        _db.Apartments.Add(apartment);
        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("apartments/{id}")]
    public async Task<ActionResult> DeleteApartment(int id)
    {
        _db.Apartments.RemoveRange(_db.Apartments.Where(c =>
            c.Id == id &&
            c.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(
                HttpContext.GetUser())));

        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("apartments/{id}")]
    public async Task<ActionResult<ApartmentViewModel>> GetApartment(int id)
    {
        return _mapper.Map<ApartmentViewModel>(
            await _db.Apartments
                .Include(a => a.Tenants)
                .Include(a => a.TenantsWhoMainThis)
                .Include(a => a.Owner)
                .Include(a => a.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany)
                .FirstAsync(c =>
                    c.Id == id &&
                    c.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(
                        HttpContext.GetUser()))
        );
    }
    
    [HttpPut("apartments/{id}")]
    public async Task<ActionResult<ApartmentViewModel>> PutApartment(int id, ApartmentPut apartment)
    {
        var entity = _db.Apartments
            .Include(a => a.Tenants)
            .Include(a => a.TenantsWhoMainThis)
            .Include(a => a.Owner)
            .Include(a => a.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany)
            .FirstOrDefault(a => a.Id == id);
 
        if (entity == null)
        {
            return NotFound();
        }

        if (entity.Id != apartment.Id)
        {
            return BadRequest();
        }

        entity.Area = apartment.Area;
        entity.Area = apartment.Area;

        _mapper.Map(apartment, entity);

        _db.SaveChangesAsync();
    
        return Ok(_mapper.Map<ApartmentViewModel>(entity));
    }
    
    [HttpPost("codes")]
    public async Task<ActionResult> CreateCode(int apartmentId)
    {
        var apartment = await _db.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId && a.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser()));

        if (apartment == null)
            return BadRequest();

        var uniqueCode = Guid.NewGuid().ToString()[0..6];
        while (_db.InviteCodes.Where(i => i.Code == uniqueCode).Count() > 0)
        {
            uniqueCode = Guid.NewGuid().ToString()[0..6];
        }

        var newCode = new InviteCode()
        {
            Apartment = apartment,
            Code = uniqueCode
        };

        _db.InviteCodes.Add(newCode);
          
        await _db.SaveChangesAsync();

        return Ok();
    }
    
    [HttpDelete("codes/{id}")]
    public async Task<ActionResult> DeleteCode(int id)
    {
        var code = await _db.InviteCodes.FirstOrDefaultAsync(a => a.Id == id && a.Apartment.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser()));

        if (code == null)
            return BadRequest();
        
        _db.InviteCodes.Remove(code);
          
        await _db.SaveChangesAsync();

        return Ok();
    }
    
    [HttpPost("apartments/{apartmentId}/devices")]
    public async Task<ActionResult> CreateApartmentSmartHomeDevices(int apartmentId, SmartHomeDeviceCreate deviceCreate)
    {
        var apartment = await _db.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId && a.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser()));

        if (apartment == null)
            return BadRequest();

        var newDevice = new SmartHomeDevice()
        {
            Apartment = apartment,
            SmartHomeDeviceType = deviceCreate.SmartHomeDeviceType
        };

        _db.SmartHomeDevices.Add(newDevice);

        await _db.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpDelete("devices/{deviceId}")]
    public async Task<ActionResult> DeleteSmartHomeDevices(int deviceId)
    {
        var device = await _db.SmartHomeDevices.FirstOrDefaultAsync(a => a.Id == deviceId && a.Apartment.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser()));

        if (device == null)
            return BadRequest();
        
        _db.SmartHomeDevices.Remove(device);
          
        await _db.SaveChangesAsync();

        return Ok();
    }
}