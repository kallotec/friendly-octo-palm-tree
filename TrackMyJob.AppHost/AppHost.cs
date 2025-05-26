var builder = DistributedApplication.CreateBuilder(args);

var webApi = builder.AddProject<Projects.TrackMyJob_API>("web-api")
    .WithExternalHttpEndpoints();
    
builder.AddNpmApp("react", "../TrackMyJob.Web")
    .WithReference(webApi)
    .WaitFor(webApi)
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    .WithHttpEndpoint(port: 8089)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

await builder.Build().RunAsync().ConfigureAwait(false);
