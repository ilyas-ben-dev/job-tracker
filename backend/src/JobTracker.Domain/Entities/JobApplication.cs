using JobTracker.Domain.Enums;
namespace JobTracker.Domain.Entities;
public class JobApplication
{
	public int Id { get; set; }
	public required string JobTitle { get; set; }
	public ApplicationStatus Status { get; set; }
	public DateOnly? ApplicationDate { get; set; }
	public string? Link { get; set; }
	public int CompanyId { get; set; }
	public Company Company { get; set; } = null!;
}


