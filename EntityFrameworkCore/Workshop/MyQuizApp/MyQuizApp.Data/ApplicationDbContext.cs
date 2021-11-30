using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyQuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyQuizApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Quiz> Quizes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAnswer>()
                .HasKey(x => new { x.IdentityUserId, x.QuestionId });

            builder.Entity<UserAnswer>()
                .HasOne(x => x.Question)
                .WithMany(x => x.UserAnswers)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
