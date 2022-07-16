using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Domovoy.SmartHome;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domovoy.Controllers;

[Authorize("Tenant")]
[Route("api/[controller]")]
[ApiController]
public class SmartHomeDevicesController: ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly IServiceProvider _provider;

    public SmartHomeDevicesController(ApplicationDbContext db, IMapper mapper, IServiceProvider provider)
    {
        _db = db;
        _mapper = mapper;
        _provider = provider;
    }

    [HttpGet("apartment/{apartmentId}")]
    public async Task<ActionResult<List<SmartHomeDeviceDTO>>> GetApartmentSmartHomeDevices(int apartmentId)
    {
        return _mapper.Map<List<SmartHomeDeviceDTO>>(await _db.SmartHomeDevices.Where(d => d.Apartment.Id == apartmentId && d.Apartment.Tenants.Contains(HttpContext.GetUser())).ToListAsync());
    }
    
    [HttpPost("use/{deviceId}")]
    public async Task<ActionResult> UseDevice(int deviceId, [FromQuery] string actionId)
    {
        var device = await _db.SmartHomeDevices.FirstOrDefaultAsync(d => d.Id == deviceId && d.Apartment.Tenants.Contains(HttpContext.GetUser()));
        if (device == null) return BadRequest("Device not found");

        var handler = _provider.GetServices<ISmartHomeDeviceHandler>().First(h => h.SmartHomeDeviceType == device.SmartHomeDeviceType);
        var action = handler.Actions.FirstOrDefault(a => a.ActionId == actionId);
        if (action == null) return BadRequest("Action not found");

        await action.Perform(device, _db);

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("updates/{deviceId}")]
    public async Task<ActionResult<List<SmartHomeDeviceActionLogEntryDTO>>> GetUpdates(int deviceId)
    {
        var updates = await _db.SmartHomeDeviceActionLog.Where(e => e.SmartHomeDevice.Id == deviceId && e.Perfomed == false).ToListAsync();
        foreach (var update in updates) update.Perfomed = true;
        await _db.SaveChangesAsync();
        foreach (var update in updates) update.Perfomed = false;
        return _mapper.Map<List<SmartHomeDeviceActionLogEntryDTO>>(updates);
    }
}