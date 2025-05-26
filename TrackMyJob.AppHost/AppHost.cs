var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TrackMyJob_API>("web-api");

await builder.Build().RunAsync().ConfigureAwait(false);
