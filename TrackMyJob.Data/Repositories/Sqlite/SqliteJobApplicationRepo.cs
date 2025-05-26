using Microsoft.EntityFrameworkCore;
using TrackMyJob.Data;
using TrackMyJob.Domain.Models;
namespace TrackMyJob.Domain.Repos.Sqlite;

public class SqliteJobApplicationRepo : IJobApplicationRepo
{
    public async Task<string> Insert(JobApplication jobApplication)
    {
        using var context = new SqliteDbContext();
        var inserted = await context.JobApplications.AddAsync(jobApplication);
        await context.SaveChangesAsync();
        return inserted.Entity.Id!;
    }

    public async Task<JobApplication[]> GetByUserId(string userId)
    {
        using var context = new SqliteDbContext();
        return await context.JobApplications.ToArrayAsync();
    }
}
