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
    public async IAsyncEnumerable<Chat> GetChats()
    {
        ApplicationUser user = HttpContext.GetUser();
        List<Apartment> apartments = _db.Apartments
            .Where(a => a.Owner == user)
            .Include(i => i.HouseEntrance.ApartmentHouse.HouseChat)
            .ToList();

        await foreach (var chat in _db.Chats)
        {
            foreach (var apartment in apartments)
            {
                if (chat.Users.Contains(user) || chat == apartment.HouseEntrance.ApartmentHouse.HouseChat)
                    yield return chat;
            }
        }
    }

    [HttpPost ("add")]
    public async Task<ActionResult> AddChat(List<int> userIds)
    {
        _db.Chats.Add(new Chat("", _db.Users.Where(c => userIds.Contains(c.Id)).ToList()));
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet ("{chatId}")]
    public async Task<ActionResult<List<Message>>> ShowChat(int chatId, [FromQuery] DateTime? since)
    {
        bool access = await UserHasAccess(chatId, HttpContext);
        if (access == false)
            return Forbid();

        return await _db.Messages
            .Where(c => c.ChatId == chatId && (c.SentAt > since || since == null))
            .OrderByDescending(s => s.SentAt)
            .Take(50)
            .ToListAsync();
    }

    [HttpPost ("{chatId}/send")]
    public async Task<ActionResult> SentMessage(string text, int chatId)
    {
        bool access = await UserHasAccess(chatId, HttpContext);
        if (access == false)
            return Forbid();

        await _db.Messages.AddAsync(new Message(text, _db.Chats.First(c => c.Id == chatId)));
        await _db.SaveChangesAsync();
        return Ok();
    }

    async Task<bool> UserHasAccess(int chatId, HttpContext HttpContext)
    {
        Chat chat = _db.Chats.FirstOrDefault(c => c.Id == chatId);
        ApplicationUser user = HttpContext.GetUser();
        if (chat != null &&
            (chat.Users.Contains(user) ||
             user.Apartments.Where(a => a.HouseEntrance.ApartmentHouse.Id == chat.ApartmentHouse.Id) != null))
            return false;
        else return true;
    }
}