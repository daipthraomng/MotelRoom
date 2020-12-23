using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotelRoom.Areas.Identity.Data;
using MotelRoom.Data;

[assembly: HostingStartup(typeof(MotelRoom.Areas.Identity.IdentityHostingStartup))]
namespace MotelRoom.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        
        public void Configure(IWebHostBuilder builder)
        {
            // injection for DbContext
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));
                // injection for identity default user authentication schema is selected by calling this function(AddDefaultIdentity)
                services.AddDefaultIdentity<AppUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;// false (don't need to confirm email when register)
                    options.Password.RequireLowercase = false; // false (passwork needn't has a lowercase)
                    options.Password.RequireUppercase = false; // false (passwork needn't has a uppercase)
                    options.Password.RequireNonAlphanumeric = false; // false (passwork needn't has a ky tu dac biet)
                }).AddRoles<IdentityRole>() // dong nay de khai bao identity role to use in register.cshtml.cs
                    
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}