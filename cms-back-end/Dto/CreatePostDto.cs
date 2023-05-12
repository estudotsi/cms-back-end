using cms_back_end.Models;

namespace cms_back_end.Dto
{
	public class CreatePostDto
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public int CategoryId { get; set; }
	}
}
