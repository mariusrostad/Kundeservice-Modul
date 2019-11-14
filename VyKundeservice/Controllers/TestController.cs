using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VyKundeservice.Persistence;
using WebUi.Models;

namespace VyKundeservice.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController 
    {
        private readonly VyDbContext _context;
        public TestController(VyDbContext context) 
        {
            _context = context;
        }

        public void Index() 
        {
            var questions = new List<Question>();
            var admin = new Category
            {
                Name = "Admin"
            };
            _context.Categories.Add(admin);
            admin = _context.Categories.FirstOrDefault(n => n.Name.Equals("Admin"));

            var adminq1 = new Question
            {
                Message = "Question 1",
                Category = admin
            };
            questions.Add(adminq1);
            _context.Questions.Add(adminq1);

            var adminq2 = new Question
            {
                Message = "Question 2",
                Category = admin
            };
            questions.Add(adminq2);
            _context.Questions.Add(adminq2);

            var adminq3 = new Question
            {
                Message = "Question 3",
                Category = admin
            };
            questions.Add(adminq3);
            _context.Questions.Add(adminq3);

            _context.SaveChanges();

            // Billett
            //var billettQuestions = new List<Question>();
            //var billett = new Category 
            //{
            //    Name = "Billett"
            //};

            //var billettq1 = new Question 
            //{
            //    Message = "Question 1",
            //    Category = billett
            //};
            //billettQuestions.Add(billettq1);

            //var billettq2 = new Question 
            //{
            //    Message = "Question 2",
            //    Category = billett
            //};
            //billettQuestions.Add(billettq2);

            //var billettq3 = new Question 
            //{
            //    Message = "Question 3",
            //    Category = billett
            //};
            //billettQuestions.Add(billettq3);

            //// Avganger
            //var avgangerQuestions = new List<Question>();
            //var avganger = new Category 
            //{
            //    Name = "Avganger"
            //};

            //var avgangerq1 = new Question 
            //{
            //    Message = "Question 1",
            //    Category = avganger
            //};
            //avgangerQuestions.Add(avgangerq1);

            //var avgangerq2 = new Question 
            //{
            //    Message = "Question 2",
            //    Category = avganger
            //};
            //avgangerQuestions.Add(avgangerq2);

            //var avgangerq3 = new Question 
            //{
            //    Message = "Question 3",
            //    Category = avganger
            //};
            //avgangerQuestions.Add(avgangerq3);

            //// Kvittering
            //var kvitteringQuestions = new List<Question>();
            //var kvittering = new Category 
            //{
            //    Name = "Kvittering"
            //};

            //var kvitteringq1 = new Question 
            //{
            //    Message = "Question 1",
            //    Category = kvittering
            //};
            //kvitteringQuestions.Add(kvitteringq1);

            //var kvitteringq2 = new Question 
            //{
            //    Message = "Question 2",
            //    Category = kvittering
            //};
            //kvitteringQuestions.Add(kvitteringq2);

            //var kvitteringq3 = new Question 
            //{
            //    Message = "Question 3",
            //    Category = kvittering
            //};
            //kvitteringQuestions.Add(kvitteringq3);
        }
    }
}