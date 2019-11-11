using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUi.Models;
using WebUi.Persistence;

namespace WebUi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryQuestionsController : ControllerBase
    {
        private readonly VyDbContext _context;

        public CategoryQuestionsController(VyDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoryQuestions/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion(int id)
        {
            var question = await _context.Questions.Include(q => q.Category).Where(c => c.Category.Id == id).ToListAsync();

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }
    }
}