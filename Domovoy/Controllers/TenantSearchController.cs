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
public class TenantSearchController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public TenantSearchController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<ActionResult<List<ApartmentViewModel>>> Search(SerachFilters filters)
    {
        if (filters.ApartmentState == ApartmentState.NotForSell || filters.ApartmentState == ApartmentState.Booked)
            return BadRequest();
        
        var preResults = await _mapper.ProjectTo<ApartmentViewModel>(_db.Apartments
            .Where(a =>
                a.Owner.Id != HttpContext.GetUser().Id &&
                !a.Tenants.Contains(HttpContext.GetUser()) &&
                (filters.ApartmentState != null ? a.ApartmentState == filters.ApartmentState : a.ApartmentState != ApartmentState.Booked && a.ApartmentState != ApartmentState.NotForSell) &&
                (filters.ApartmentType != null ? a.ApartmentType == filters.ApartmentType : true) &&
                a.Cost >= filters.CostMin &&
                (filters.CostMax != null && filters.CostMax != 0 ? a.Cost <= filters.CostMax : true) &&
                a.RoomCount >= filters.RoomCountMin &&
                (filters.RoomCountMax != null && filters.RoomCountMax != 0 ? a.RoomCount <= filters.RoomCountMax : true)
            )
        ).ToListAsync();
        
        return preResults.Where(a =>
            a.HouseEntrance.ApartmentHouse.Address.City == filters.City
        ).ToList();
    }
}