using cms_back_end.Data;
using cms_back_end.Dto;
using cms_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cms_back_end.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoriesController : ControllerBase
	{
		private readonly DataContext _context;

		public CategoriesController(DataContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<ActionResult<Category>> Create([FromBody] CreateCategoryDto categoryDto)
		{
            var newCategory = new Category
            {
               Nome = categoryDto.Nome,
            };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

			return(newCategory);
        }

        /*[HttpGet]
		public async Task<ActionResult<List<Category>>> List()
		{
			return await _context.Categories.ToListAsync();
		}*/

        [HttpGet]
		public async Task<ActionResult<List<Category>>> List()
		{
			return await _context.Categories.Include(c => c.Posts).ToListAsync();
		}

        [HttpDelete("{idCategory}")]
		public async Task<ActionResult<Category>> Delete(int idCategory)
		{
			Category categoryFind = await _context.Categories.FirstOrDefaultAsync(x => x.Id == idCategory);
			_context.Categories.Remove(categoryFind);
			await _context.SaveChangesAsync();

			return NoContent();

		}

        /*[HttpGet("{id}")]
		public async Task<ActionResult<List<Category>>> GetById(int id)
		{
			Category categories = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

			return Ok(categories);
		}*/

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var categories = await _context.Categories.Where(c => c.Id == id).Include(c => c.Posts).ToListAsync();
			return Ok(categories);
        }

        [HttpPut("{idCategory}")]
		public async Task<ActionResult<Category>> Update([FromBody] Category category, int idCategory)
		{
			Category categoryFind = await _context.Categories.FirstOrDefaultAsync(x => x.Id == idCategory);

			categoryFind.Nome = category.Nome;

			_context.Categories.Update(categoryFind);
			await _context.SaveChangesAsync();

			return NoContent();

		}
	}
}

