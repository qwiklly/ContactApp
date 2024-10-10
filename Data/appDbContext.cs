using ContactApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data
{
	public class appDbContext(DbContextOptions<appDbContext> options) : DbContext(options)
	{
		public DbSet<Contact> Contacts { get; set; }
	}
}




