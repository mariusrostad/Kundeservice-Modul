using Microsoft.EntityFrameworkCore;
using WebUi.Models;

namespace WebUi.Persistence {
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