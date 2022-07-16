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

[Route("api/[controller]")]
[ApiController]
public class ChatService : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ChatService(ApplicationDbContext db, IMapper mapper)
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

    public async Task<ActionResult> AddChat(List<ApplicationUser> users)
    {
        await _db.Chats.AddAsync(new Chat("", users));
        return Ok();
    }

    public async Task<ActionResult<List<Message>>> ShowChat(int chatId)
    {
        return await _db.Messages
            .Where(c => c.ChatId == chatId)
            .OrderByDescending(s => s.SentAt)
            .Take(50)
            .ToListAsync();
    }

    public async Task<ActionResult> SentMessage(string text, int chatId)
    {
        await _db.Messages.AddAsync(new Message(text, _db.Chats.First(c => c.Id == chatId)));
        return Ok();
    }
}