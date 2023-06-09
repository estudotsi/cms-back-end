﻿using cms_back_end.Data;
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

        [HttpGet]
        public async Task<ActionResult<List<Post>>> ListAll()
        {
            var dto = await _context.Posts.Include(c => c.Category).ToListAsync();
			return dto;
        }

        [HttpGet("listForId/{postId}")]
        public async Task<ActionResult<Post>> ListForId(int postId)
        {
			var postForId = await _context.Posts.Include(c => c.Category).Where(x => x.Id == postId).FirstOrDefaultAsync();
			if(postForId == null)
			{
                throw new NotImplementedException("Esse post não existe");
            }
            return postForId;
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
				Permalink= postDto.Permalink,
				PostImaTitle = postDto.PostImaTitle,
				Excerpt= postDto.Excerpt,
				isFeatured =postDto.isFeatured,
				Views = postDto.Views,
				Status= postDto.Status,
				CreatedAt= postDto.CreatedAt,
				Content = postDto.Content,
				Category = categorie
			};

			_context.Posts.Add(newPost);
			await _context.SaveChangesAsync();

			return await ListForCategories(postDto.CategoryId);
		}
	}
}


