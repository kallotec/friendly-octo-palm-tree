using TrackMyJob.Domain.Infrastructure;
using TrackMyJob.Domain.Repos;
namespace TrackMyJob.Domain.Services;

public class JobApplier(IJobApplicationRepo jobAppRepo, IClock clock)
{
    /// <returns>New job application id</returns>
    public async Task<string> Apply(string companyName, string positionTitle)
    {
        var getNowTicks = clock.GetUtcTicks();

        var newId = await jobAppRepo.Insert(new()
        {
            CompanyName = companyName,
            PositionTitle = positionTitle,
            AppliedAtUtcTicks = getNowTicks
        });
        
        return newId;
    }
}