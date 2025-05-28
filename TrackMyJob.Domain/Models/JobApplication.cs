using System.ComponentModel.DataAnnotations.Schema;
namespace TrackMyJob.Domain.Models;

public class JobApplication
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; }
    public required string CompanyName { get; set; }
    public required string PositionTitle { get; set; }
    public required long AppliedAtUtcTicks { get; set; }
}