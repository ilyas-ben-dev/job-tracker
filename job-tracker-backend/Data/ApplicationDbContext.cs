using job_tracker_backend.Entities;
using job_tracker_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace job_tracker_backend.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users => Set<User>();
		public DbSet<JobApplication> JobApplications => Set<JobApplication>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				   new User
				   {
					   Id = 1,
					   Email = "demo@jobtracker.test",
					   PasswordHash = "SEED_PLACEHOLDER"   
				   }
			   );

			modelBuilder.Entity<JobApplication>().HasData(
				new JobApplication
				{
					Id = 1,
					Company = "Spotify",
					Position = "Junior .NET Developer",
					Status = ApplicationStatus.Applied,
					ApplicationDate = new DateTime(2026, 11, 1),   
					OfferUrl = "https://example.com/offer/1",
					ExpectedSalary = 3200m,
					Notes = "Candidature test",
					UserId = 1  
				},
				new JobApplication
				{
					Id = 2,
					Company = "Microsoft",
					Position = "Backend Intern",
					Status = ApplicationStatus.ToApply,
					ApplicationDate = new DateTime(2026, 11, 5),
					UserId = 1
				}
			);
		}
	}
}
