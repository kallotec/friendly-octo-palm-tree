var builder = DistributedApplication.CreateBuilder(args);

var webapi = builder.AddProject<Projects.TrackMyJob_API>("webapi");

builder.AddNpmApp("react", "../TrackMyJob.Web")
    .WithReference(webapi)
    .WaitFor(webapi)
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

await builder.Build().RunAsync().ConfigureAwait(false);
