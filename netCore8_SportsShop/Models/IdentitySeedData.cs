using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCore8_SportsShop.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

                var userManager = (UserManager<IdentityUser>)scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>));

                IdentityUser user = await userManager.FindByIdAsync(adminUser);
                if (user == null)
                {
                    user = new IdentityUser("Admin");
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
        }

        //public static async void Initialize(IApplicationBuilder app)
        //{
        //    UserManager<IdentityUser> userManager = app.ApplicationServices
        //    .GetRequiredService<UserManager<IdentityUser>>();
        //    IdentityUser user = await userManager.FindByIdAsync(adminUser);
        //    if (user == null)
        //    {
        //        user = new IdentityUser("Admin");
        //        await userManager.CreateAsync(user, adminPassword);
        //    }
        //}
    }
}
