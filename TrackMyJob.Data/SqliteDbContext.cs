using Microsoft.EntityFrameworkCore;
using TrackMyJob.Domain.Models;
namespace TrackMyJob.Data;

public class SqliteDbContext : DbContext
{
    public DbSet<JobApplication> JobApplications { get; set; }
    readonly string _dbPath;

    public SqliteDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        _dbPath = Path.Join(path, "TrackMyJob.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={_dbPath}");
}
