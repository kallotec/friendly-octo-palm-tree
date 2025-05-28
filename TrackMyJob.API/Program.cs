using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TrackMyJob.Data;
using TrackMyJob.Domain.Repos;
using TrackMyJob.Domain.Repos.Sqlite;
using TrackMyJob.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddLogging();
injectServices(builder.Services);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupSwaggerDocs);
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler();
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();

// start application
await app.RunAsync().ConfigureAwait(continueOnCapturedContext: false);


void injectServices(IServiceCollection services)
{
    services.AddScoped<IJobApplicationRepo, SqliteJobApplicationRepo>();
    services.AddScoped<SqliteDbContext>();
}

void setupSwaggerDocs(SwaggerGenOptions opts)
{
#pragma warning disable S1075 // URIs should not be hardcoded
    OpenApiInfo info = new()
    {
        Version = "v1",
        Title = "TrackMyJob API",
        Description = "An API for tracking your job applications",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    };
#pragma warning restore S1075 // URIs should not be hardcoded
    opts.SwaggerDoc("v1", info);
}