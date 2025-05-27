using TrackMyJob.Domain.Models;
namespace TrackMyJob.Domain.Repos;

public interface IJobApplicationRepo
{
    Task<JobApplication[]> GetAll();
    Task<JobApplication?> GetById(string id);
    Task<string> Insert(JobApplication jobApplication);
    Task<bool> Update(JobApplication jobApplication);
    Task<bool> Delete(string id);
}