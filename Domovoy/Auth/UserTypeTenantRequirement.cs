using System.Security.Claims;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Domovoy.Auth;

public class UserTypeTenantRequirement : IAuthorizationRequirement
{
    public UserTypeTenantRequirement()
    {
    }
}

public class UserTypeTenantAuthorizationHandler : AuthorizationHandler<UserTypeTenantRequirement>
{
    private readonly ApplicationDbContext _db;
    public UserTypeTenantAuthorizationHandler(ApplicationDbContext db)
    {
        _db = db;
    }
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserTypeTenantRequirement requirement)
    {
        if (!context.User.HasClaim(x => x.Type == ClaimTypes.Name))
            return;

        var id = int.Parse(context.User.Claims.First(c => c.Type == ClaimTypes.Name).Value);

        if ((await _db.Users.FirstAsync((u) => u.Id == id)).Type == ApplicationUserType.Tenant)
        {
           context.Succeed(requirement);
        }

        return;
    }
}