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
        return await _db.Chats
            .Where(c => c.Users.Contains(HttpContext.GetUser()))
            .ToListAsync();
    }

    [HttpPost ("add")]
    public async Task<ActionResult> AddChat(List<int> userIds)
    {
        _db.Chats.Add(new Chat("", _db.Users.Where(c => userIds.Contains(c.Id)).ToList()));
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet ("{chatId}")]
    public async Task<ActionResult<List<Message>>> ShowChat(int chatId)
    {
        return await _db.Messages
            .Where(c => c.ChatId == chatId)
            .OrderByDescending(s => s.SentAt)
            .Take(50)
            .ToListAsync();
    }

    [HttpPost ("{chatId}/send")]
    public async Task<ActionResult> SentMessage(string text, int chatId)
    {
        await _db.Messages.AddAsync(new Message(text, _db.Chats.First(c => c.Id == chatId)));
        await _db.SaveChangesAsync();
        return Ok();
    }
}