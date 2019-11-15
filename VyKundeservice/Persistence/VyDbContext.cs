using Microsoft.EntityFrameworkCore;
using VyKundeservice.Models;

namespace VyKundeservice.Persistence {
    public class VyDbContext : DbContext {
        public VyDbContext(DbContextOptions<VyDbContext> options) : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}