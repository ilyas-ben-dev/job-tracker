using JobTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Infrastructure.Persistence
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{

		}

		public DbSet<Company> Companies { get; set; }
		public DbSet<JobApplication> JobApplications { get; set; }


	}
}

