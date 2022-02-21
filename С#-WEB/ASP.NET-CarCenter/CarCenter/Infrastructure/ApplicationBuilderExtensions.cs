using CarCenter.Data;
using CarCenter.Data.Common;
using CarCenter.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarCenter.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
                this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
            SeedAdmin(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<CarCenterDbContext>();

            data.Database.Migrate();
        }


        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<IRepository>();

            if (data.All<Category>().Any())
            {
                return;
            }

            data.All<Category>().ToList().AddRange(new[]
            {
                new Category { Type = "Mini" },
                new Category { Type = "Economy" },
                new Category { Type = "Midsize" },
                new Category { Type = "Large" },
                new Category { Type = "SUV" },
                new Category { Type = "Vans" },
                new Category { Type = "Luxury" },
            });

            data.SaveChanges();
        }

        private static void SeedAdmin(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Admin"))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = "Admin" };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "mechanic@go.com";
                    const string adminPassword = "admin123";

                    var user = new IdentityUser
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, "Admin");
                })
                .GetAwaiter()
                .GetResult();

        }
    }
}
