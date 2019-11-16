using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VyKundeservice.Models;
using VyKundeservice.Persistence;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace VyKundeservice.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuestionsController : Controller
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

        // POST api/Kunde
        [HttpPost]
        public ActionResult<UserQuestion> Post([FromBody]userquestion inUserQuestion)
        {
            
            if (ModelState.IsValid)
            {
                var userQuestion = new UserQuestion
                {
                    Firstname = inUserQuestion.firstname,
                    Lastname = inUserQuestion.lastname,
                    Question = inUserQuestion.question,
                    CategoryId = inUserQuestion.categoryId
                };

                try
                {
                    // lagre kunden
                    _context.UserQuestions.Add(userQuestion);
                    _context.SaveChanges();
                    return userQuestion;
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
            return NotFound();
        }

        // [HttpPost]
        // public async Task<ActionResult<Question>> PostQuestion([FromBody]UserQuestionDTO userQuestion) 
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var newQuestion = new UserQuestion
        //         {
        //             Firstname = userQuestion.firstname,
        //             Lastname = userQuestion.lastname,
        //             Question = userQuestion.question,
        //             CategoryId = userQuestion.categoryId
        //         };
        //         _context.UserQuestions.Add(newQuestion);
            
        //         await _context.SaveChangesAsync();
        //         return CreatedAtAction("GetUserQuestion", new { id = newQuestion.Id }, newQuestion);
        //     }
        //     return NotFound();
        // }
    }
}