using System;
using WebUi.Model;
using Microsoft.EntityFrameworkCore;

namespace WebUi.Persistence {
    public class VyDbContext : DbContext {
        public VyDbContext(DbContextOptions<VyDbContext> options) : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(q => q.Questions)
                .WithOne(c => c.Category);
        }
    }
}