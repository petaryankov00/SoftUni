using FootballManager.Data.Common;
using FootballManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Data
{
    public class FootballManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }

        public DbSet<Player> Players { get; init; }

        public DbSet<UserPlayer> UsersPlayers { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataConstants.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPlayer>()
                .HasKey(x => new { x.UserId, x.PlayerId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
