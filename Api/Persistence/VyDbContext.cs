using System;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence {
    public class VyDbContext : DbContext {
        public VyDbContext(DbContextOptions<VyDbContext> options) : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}