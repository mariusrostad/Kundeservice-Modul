using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VyKundeservice.Models;
using VyKundeservice.Persistence;

namespace VyKundeservice.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly VyDbContext _context;

        public RatingController(VyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string Get() 
        {
            return "Get";
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<Question>> Like(int id)
        {
            if (id == default) 
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            question.Likes = question.Likes + 1;

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();

            return question;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<Question>> Dislike(int id)
        {
            if (id == default) 
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            question.Dislikes = question.Dislikes + 1;

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();

            return question;
        }
    }
}