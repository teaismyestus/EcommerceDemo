using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcWebUI.Areas.Identity.Data;
using MvcWebUI.CustomValidators;
using MvcWebUI.Data;

[assembly: HostingStartup(typeof(MvcWebUI.Areas.Identity.IdentityHostingStartup))]
namespace MvcWebUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));


                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;


                }).AddRoles<AppRole>().AddErrorDescriber<CustomIdentityValidator>()
                    .AddEntityFrameworkStores<AuthDbContext>();
                

            });
            
        }
    }
}