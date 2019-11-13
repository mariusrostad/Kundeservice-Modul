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
    public class FaqController : ControllerBase
    {
        private readonly VyDbContext _context;

        public FaqController(VyDbContext context)
        {
            _context = context;
        }

        // GET: api/Faq
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetFaq()
        {
            var categories = await _context.Categories.ToListAsync();
            var cateogriesDto = new List<CategoryDTO>();
            foreach(var category in categories) 
            {
                var newCategoryDto = new CategoryDTO 
                {
                    Id = category.Id,
                    Name = category.Name
                };
                
                var questions = _context.Questions.Where(q => q.Category.Id == category.Id).Include(q => q.Answers).ToList();

                newCategoryDto.Questions = questions;

                cateogriesDto.Add(newCategoryDto);
            }

            return cateogriesDto;
        }
    }
}