using System.Security.Claims;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Domovoy.Auth;

public class UserTypeAgentRequirement : IAuthorizationRequirement
{
    public UserTypeAgentRequirement()
    {
    }
}

public class UserTypeAgentAuthorizationHandler : AuthorizationHandler<UserTypeAgentRequirement>
{
    private readonly ApplicationDbContext _db;
    public UserTypeAgentAuthorizationHandler(ApplicationDbContext db)
    {
        _db = db;
    }
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserTypeAgentRequirement requirement)
    {
        if (!context.User.HasClaim(x => x.Type == ClaimTypes.Name))
            return;

        var id = int.Parse(context.User.Claims.First(c => c.Type == ClaimTypes.Name).Value);

        if ((await _db.Users.FirstAsync((u) => u.Id == id)).Type == ApplicationUserType.Agent)
        {
           context.Succeed(requirement);
        }

        return;
    }
}