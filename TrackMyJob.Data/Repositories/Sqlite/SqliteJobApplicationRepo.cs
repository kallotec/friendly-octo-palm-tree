using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TrackMyJob.Data;
using TrackMyJob.Domain.Models;
namespace TrackMyJob.Domain.Repos.Sqlite;

public class SqliteJobApplicationRepo(SqliteDbContext context) : IJobApplicationRepo
{
    public async Task<JobApplication[]> GetAll()
    {
        return await context.JobApplications.ToArrayAsync();
    }

    public async Task<JobApplication?> GetById(string id)
    {
        return await context.JobApplications.FindAsync(id);
    }

    public async Task<string> Insert(JobApplication jobApplication)
    {
        ArgumentNullException.ThrowIfNull(jobApplication);
        jobApplication.Id = null;
        var inserted = await context.JobApplications.AddAsync(jobApplication);
        await context.SaveChangesAsync();
        return inserted.Entity.Id!;
    }

    public async Task<bool> Update(JobApplication jobApplication)
    {
        ArgumentNullException.ThrowIfNull(jobApplication);

        if (!(jobApplication.Id?.Length > 0))
            throw new InvalidOperationException("Can't update as the entity's id is not set");

        var existingCount = await context.JobApplications.CountAsync(a => a.Id == jobApplication.Id);
        if (existingCount == 0)
            return false;

        context.Entry(jobApplication).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        var rowsAffected = await context.JobApplications
            .Where(a => a.Id == id)
            .ExecuteDeleteAsync();

        return rowsAffected > 0;
    }

}
