using System;
using Lei2Projecto.Areas.Identity.Data;
using Lei2Projecto.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Lei2Projecto.Areas.Identity.IdentityHostingStartup))]
namespace Lei2Projecto.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DataContextConnection")));

                services.AddDefaultIdentity<AppUser>()
                    .AddEntityFrameworkStores<DataContext>();
            });
        }
    }
}