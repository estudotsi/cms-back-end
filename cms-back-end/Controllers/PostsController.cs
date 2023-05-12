using cms_back_end.Data;
using cms_back_end.Dto;
using cms_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cms_back_end.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PostsController
	{
		private readonly DataContext _context;

		public PostsController(DataContext context)
		{
			_context = context;
		}

		[HttpGet("{categorieId}")]
		public async Task<ActionResult<List<Post>>> ListForCategories(int categorieId)
		{
			var postsForCategories = await _context.Posts.Where(x => x.CategoryId == categorieId).ToListAsync();

			return postsForCategories;
		}

		[HttpPost]
		public async Task<ActionResult<List<Post>>> Create([FromBody] CreatePostDto postDto)
		{
			var categorie = await _context.Categories.FindAsync(postDto.CategoryId);
			if (categorie == null)

				throw new NotImplementedException("Essa categoria não existe");

			var newPost = new Post
			{
				Title = postDto.Title,
				Content = postDto.Content,
				Category = categorie
			};

			_context.Posts.Add(newPost);
			await _context.SaveChangesAsync();

			return await ListForCategories(postDto.CategoryId);
		}
	}
}

