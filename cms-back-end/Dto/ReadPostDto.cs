using cms_back_end.Models;

namespace cms_back_end.Dto
{
    public class ReadPostDto
    {
        public string Title { get; set; }
        public string Permalink { get; set; }
        public string PostImaTitle { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public bool isFeatured { get; set; }
        public int Views { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
       public Category Category { get; set; }
    }
}
