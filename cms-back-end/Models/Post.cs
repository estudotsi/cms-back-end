﻿using System.Text.Json.Serialization;

namespace cms_back_end.Models
{
	public class Post
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Permalink { get; set; }
        public string PostImaTitle { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public bool isFeatured { get; set; }
        public int Views { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public int CategoryId { get; set; }
    }
}
