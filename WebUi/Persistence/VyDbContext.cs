using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebUi.Models;

namespace WebUi.Persistence {
    public class VyDbContext : DbContext {
        public VyDbContext(DbContextOptions<VyDbContext> options) : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var questionsTest = new List<Question>();
            var q1 = new Question 
            {
                Id = -1,
                Message = "Hello World"
            };
            questionsTest.Add(q1);

            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasData(
                new Category 
                {
                    Id = -1,
                    Name = "Test 1"
                }
            );
        }
    }
}