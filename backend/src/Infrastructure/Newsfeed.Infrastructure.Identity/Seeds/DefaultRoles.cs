using Microsoft.AspNetCore.Identity;
using Newsfeed.Infrastructure.Identity.Enums;

namespace Newsfeed.Infrastructure.Identity.Seeds;
public class DefaultRoles
{
    public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(RoleDefault.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(RoleDefault.AdminApp.ToString()));
        await roleManager.CreateAsync(new IdentityRole(RoleDefault.Employee.ToString()));
    }
}
