using TrackMyJob.Domain.Models;

namespace TrackMyJob.API.Models;

public sealed record JobApplicationViewModel(string Id, string CompanyName, string PositionTitle)
{
    public static JobApplicationViewModel Map(JobApplication jobApplication)
    {
        ArgumentNullException.ThrowIfNull(jobApplication);
        return new(jobApplication.Id!, jobApplication.CompanyName, jobApplication.PositionTitle);
    }
}
