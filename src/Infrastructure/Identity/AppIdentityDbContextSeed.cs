using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));//admin rolü eklendi.
            var adminUser = new ApplicationUser()
            {
                UserName = "adminuser@example.com",
                Email = "adminuser@example.com",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(adminUser, "P@ssword1");
            await userManager.AddToRoleAsync(adminUser, "Admin");//admin ataması yapıldı

            var demoUser = new ApplicationUser()
            {
                UserName = "demouser@example.com",
                Email = "demouser@example.com",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(demoUser, "P@ssword1");


        }
    }
}
