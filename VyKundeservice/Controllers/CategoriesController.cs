using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VyKundeservice.Persistence;
using VyKundeservice.Models;

namespace VyKundeservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly VyDbContext _context;

        public CategoriesController(VyDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var cateogriesDto = new List<CategoryDTO>();
            foreach(var category in categories) 
            {
                var newCategoryDto = new CategoryDTO 
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };
                
                var questions = _context.Questions.Where(q => q.Category.CategoryId == category.CategoryId).ToList();
                newCategoryDto.Questions = questions;

                cateogriesDto.Add(newCategoryDto);
            }

            return cateogriesDto;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            var questions = await _context.Questions.Where(q => q.Category.CategoryId == id).ToListAsync();

            return new CategoryDTO 
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Questions = questions
            };
        }

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
