using System.ComponentModel.DataAnnotations;
using TrackMyJob.API.Infrastructure;
using TrackMyJob.Domain.Models;
namespace TrackMyJob.API.Models;

public sealed class JobApplicationEditModel
{
    [Required]
    [MinLength(3, ErrorMessage = "Company name should be at least 3 chars long")]
    public required string CompanyName { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Position title should be at least 3 chars long")]
    public required string PositionTitle { get; set; }


    public JobApplication Map() => new()
    {
        CompanyName = CompanyName,
        PositionTitle = PositionTitle
    };
}