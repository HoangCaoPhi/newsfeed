using Microsoft.AspNetCore.Identity;
using Newsfeed.Infrastructure.Identity.Enums;
using Newsfeed.Infrastructure.Identity.Models;

namespace Newsfeed.Infrastructure.Identity.Seeds;

/// <summary>
/// Seed default user admin
/// </summary>
public class DefaultAdmin
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
    {
        var defaultUser = new ApplicationUser
        {
            UserName = "hoangphi116",
            Email = "hoangphi123@gmail.com",
            FirstName = "Hoàng",
            LastName = "Phi",
            EmailConfirmed = false,
            PhoneNumberConfirmed = false
        };

        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "12345678@Abc");
                await userManager.AddToRoleAsync(defaultUser, RoleDefault.Admin.ToString());
                await userManager.AddToRoleAsync(defaultUser, RoleDefault.AdminApp.ToString());
                await userManager.AddToRoleAsync(defaultUser, RoleDefault.Employee.ToString());
            }
        }
    }
}
