using CarCenter.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarCenter.Data
{
    public class CarCenterDbContext : IdentityDbContext
    {
        public CarCenterDbContext(DbContextOptions<CarCenterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; init; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(x => x.Brand)
                .WithMany(x => x.Cars)
                .HasForeignKey(x=>x.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Car>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Issue>()
                .HasOne(x => x.Car)
                .WithMany(x => x.Issues)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
