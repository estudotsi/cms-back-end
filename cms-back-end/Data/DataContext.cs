using cms_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace cms_back_end.Data
{
	public class DataContext : DbContext

	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
	}
}
