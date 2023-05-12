namespace cms_back_end.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Nome { get; set; }
        public List<Post> Posts { get; set; }
    }
}
