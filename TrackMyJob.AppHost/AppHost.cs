var builder = DistributedApplication.CreateBuilder(args);

var webapi = builder.AddProject<Projects.TrackMyJob_API>("webapi")
    .WithExternalHttpEndpoints();

builder.AddNpmApp("react", "../TrackMyJob.Web")
    .WithReference(webapi)
    .WaitFor(webapi)
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

await builder.Build().RunAsync().ConfigureAwait(false);
