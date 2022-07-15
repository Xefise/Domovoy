using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domovoy.Controllers;


public class ServiceApartamentController
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ServiceApartamentController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [Authorize("Tenant")]
    [HttpGet]
    public async Task<List<ServiceApartment>> GetServiceApartaments()
    {
        return await _db.ServiceApartments.ToListAsync();
    }
}