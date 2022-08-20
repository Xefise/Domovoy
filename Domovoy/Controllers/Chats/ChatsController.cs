using System.Linq;
using AutoMapper;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Domovoy.Controllers;

[Authorize("Tenant")]
[Route("api/[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ChatsController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Chat>>> GetChats()
    {
        ApplicationUser user = HttpContext.GetUser();
        var usersChats = _db.Chats
            .Where(c => c.Users.Contains(user));

        var userApHouses =
            _db.Apartments.Where(a => a.Owner == user).Select(a => a.HouseEntrance.ApartmentHouse);
        var housesChats = _db.Chats
            .Where(c => userApHouses.Contains(c.ApartmentHouse));

        return await usersChats.Union(housesChats).ToListAsync();

    }

    [HttpPost ("add")]
    public async Task<ActionResult> AddChat(List<int> userIds)
    {
        _db.Chats.Add(new Chat("", _db.Users.Where(c => userIds.Contains(c.Id)).ToList(), HttpContext.GetUser()));
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet ("{chatId}")]
    public async Task<ActionResult<List<Message>>> ShowChat(int chatId, [FromQuery] DateTime? since)
    {
        return await _db.Messages
            .Where(c => c.ChatId == chatId && (c.SentAt > since || since == null))
            .OrderByDescending(s => s.SentAt)
            .Take(50)
            .ToListAsync();
    }

    [HttpPost ("{chatId}/send")]
    public async Task<ActionResult> SentMessage(string text, int chatId)
    {
        await _db.Messages.AddAsync(new Message(text, _db.Chats.First(c => c.Id == chatId), HttpContext.GetUser()));
        await _db.SaveChangesAsync();
        return Ok();
    }
}