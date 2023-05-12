using System.Text.Json.Serialization;

namespace cms_back_end.Models
{
	public class Post
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
