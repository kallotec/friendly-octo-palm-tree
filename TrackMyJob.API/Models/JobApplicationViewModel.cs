using TrackMyJob.Domain.Models;
namespace TrackMyJob.API.Models;

public sealed record JobApplicationViewModel(
    string Id,
    string CompanyName,
    string PositionTitle,
    long AppliedAtUtcTicks
)
{
    public string AppliedAt => DateTimeOffset.FromFileTime(AppliedAtUtcTicks).Date.ToShortDateString();

    public static JobApplicationViewModel Map(JobApplication jobApplication)
    {
        ArgumentNullException.ThrowIfNull(jobApplication);
        return new(
            jobApplication.Id!,
            jobApplication.CompanyName,
            jobApplication.PositionTitle,
            jobApplication.AppliedAtUtcTicks
        );
    }
}
