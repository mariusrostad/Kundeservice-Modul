using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VyKundeservice.Models;
using VyKundeservice.Persistence;

namespace VyKundeservice.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuestionsController : ControllerBase
    {
        private readonly VyDbContext _context;

        public UserQuestionsController(VyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserQuestion>>> GetUserQuestions()
        {
            return await _context.UserQuestions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserQuestion>> GetUserQuestion(int id) 
        {
            return await _context.UserQuestions.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion([FromBody]UserQuestionDTO userQuestion) 
        {
            if (userQuestion.category == default || userQuestion.question == "")
            {
               Console.WriteLine("NotFound(): Category or Question is not set!");
               return NotFound();
            }

            var newQuestion = new UserQuestion
            {
                Question = userQuestion.question,
                CategoryId = userQuestion.category
            };

            _context.UserQuestions.Add(newQuestion);
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("Added to db");
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Could not save");
            }
            return CreatedAtAction("GetUserQuestion", new { id = newQuestion.UserQuestionId }, newQuestion);
        }
    }
}