using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cennet_Emlak.Data.Concrete.EfCore
{
    public class IdentitySeedDate
    {
        private const string adminUser = "admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();
            if(context.Database.GetAppliedMigrations().Any())
            {
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var user = await userManager.FindByNameAsync(adminUser);
            if(user == null)
            {
                user = new AppUser{
                    Fullname = "Kerem Yerebakan",
                    UserName = adminUser,
                    Email = "admin@sadik.com",
                    PhoneNumber ="05465464646"
                };

                await userManager.CreateAsync(user,adminPassword);
            }
        }
    }
}