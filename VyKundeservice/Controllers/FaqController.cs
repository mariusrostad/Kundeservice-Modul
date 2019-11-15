using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VyKundeservice.Models;
using VyKundeservice.Persistence;

namespace VyKundeservice.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly VyDbContext _context;

        public FaqController(VyDbContext context)
        {
            _context = context;
        }

        // GET: api/Faq
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetFaqs()
        {
            var categories = await _context.Categories.ToListAsync();

            var cateogriesDto = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                var newCategoryDto = new CategoryDTO
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };

                var questions = _context.Questions.Where(q => q.CategoryId == category.CategoryId).ToList();

                newCategoryDto.Questions = questions;

                cateogriesDto.Add(newCategoryDto);
            }

            return cateogriesDto;
        }
    }
}