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
public class TenantRecomendationsController: ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public TenantRecomendationsController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ApartmentViewModel>>> GetRecomendations()
    {
        var userApartments = await _db.Apartments.Include(a => a.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany).Where(a => a.Tenants.Contains(HttpContext.GetUser())).ToListAsync();
        var count = userApartments.Where(a => a.Cost != null).Count();
        var meanPrice = count == 0
            ? userApartments.Where(a => a.Cost != null).Select(a => a.Cost).Sum() / count
            : 3000000;

        if (userApartments.Count == 0) return new List<ApartmentViewModel>();
        
        var preResults = await _mapper.ProjectTo<ApartmentViewModel>(
            _db.Apartments
                .Include(a => a.HouseEntrance.ApartmentHouse.ResidentialComplex.ConstructionCompany)
                .Include(a => a.Owner)
                .Include(a => a.Tenants)
                .Where(a => a.Cost != null && a.ApartmentState == ApartmentState.ForSell && !a.Tenants.Contains(HttpContext.GetUser()))
                .OrderBy(a => Math.Abs(a.Cost ?? default(int) - meanPrice ?? default(int)))
        ).ToListAsync();

        return preResults
            .Where(a => a.HouseEntrance.ApartmentHouse.Address.City == userApartments[0].HouseEntrance.ApartmentHouse.Address.City)
            .Take(4)
            .ToList();
    }
}