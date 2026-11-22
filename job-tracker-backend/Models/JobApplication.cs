using job_tracker_backend.Entities;

namespace job_tracker_backend.Models
{
	public enum ApplicationStatus
	{
		ToApply, Applied,Interview, Offer, Rejected
	}
	public class JobApplication
	{
		public int Id { get; set; }
		public string Company {  get; set; }
		public string Position { get; set; }
		public ApplicationStatus Status { get; set; }
		public DateTime ApplicationDate { get; set; }
		public string? OfferUrl { get; set; }
		public decimal? ExpectedSalary { get; set; }
		public string? Notes { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}
