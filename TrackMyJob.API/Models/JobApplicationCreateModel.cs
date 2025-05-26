using System.ComponentModel.DataAnnotations;
using TrackMyJob.Domain.Models;
namespace TrackMyJob.API.Models;

public class JobApplicationCreateModel
{
    [Required]
    public required string CompanyName { get; set; }
    public required string PositionTitle { get; set; }

    public JobApplication Map() => new()
    {
        CompanyName = CompanyName,
        PositionTitle = PositionTitle
    };
}