using job_tracker_backend.Models;

namespace job_tracker_backend.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public List<JobApplication> Applications { get; set; } = new();
	}
}
