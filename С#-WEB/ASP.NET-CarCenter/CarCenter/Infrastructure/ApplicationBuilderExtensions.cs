using CarCenter.Data;
using CarCenter.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CarCenter.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            SeedCategories(services);

            return app;
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<CarCenterDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
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
    }
}
