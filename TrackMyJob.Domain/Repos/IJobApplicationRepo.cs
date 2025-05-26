using TrackMyJob.Domain.Models;
namespace TrackMyJob.Domain.Repos;

public interface IJobApplicationRepo
{
    Task<string> Insert(JobApplication jobApplication);
    Task<JobApplication[]> GetByUserId(string userId);
}