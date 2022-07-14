using System.Security.Claims;
using Domovoy.Data;
using Domovoy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Domovoy.Auth;

public class UserTypeCompanyEmloyeeRequirementRequirement : IAuthorizationRequirement
{
    public UserTypeCompanyEmloyeeRequirementRequirement()
    {
    }
}

public class UserTypeCompanyEmloyeeAuthorizationHandler : AuthorizationHandler<UserTypeCompanyEmloyeeRequirementRequirement>
{
    private readonly ApplicationDbContext _db;
    public UserTypeCompanyEmloyeeAuthorizationHandler(ApplicationDbContext db)
    {
        _db = db;
    }
    
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserTypeCompanyEmloyeeRequirementRequirement requirement)
    {
        if (!context.User.HasClaim(x => x.Type == ClaimTypes.Name))
            return Task.CompletedTask;

        if (_db.Users.First((u) => u.Id == int.Parse(context.User.Claims.First(c => c.Type == ClaimTypes.Name).Value)).Type == ApplicationUserType.ConstructionCompanyAdmin)
        {
           context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}