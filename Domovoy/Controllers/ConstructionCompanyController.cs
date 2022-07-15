using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
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
                .Where(e =>
                    e.ApartmentHouse.ResidentialComplex.Id == id &&
                    e.ApartmentHouse.ResidentialComplex.ConstructionCompany.Employees.Contains(HttpContext.GetUser()))
                .Select(b => new
                {
                    b,
                    Apartments = b.Apartments.Where(a => search != null ? a.ApartmentNumber.ToString().Contains(search) : true)
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

    [HttpPost("apartaments")]
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
}