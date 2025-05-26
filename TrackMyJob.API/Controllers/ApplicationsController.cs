using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TrackMyJob.API.Infrastructure;
using TrackMyJob.API.Models;
using TrackMyJob.Domain.Repos;
namespace TrackMyJob.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController(IJobApplicationRepo jobApplicationRepo) : ControllerBase
{
    [HttpGet]
    public async Task<JobApplicationViewModel[]> Get()
    {
        var results = await jobApplicationRepo.GetByUserId(userId: "abc");
        var mappedResults = results.Select(r => new JobApplicationViewModel(r.Id!, r.CompanyName, r.PositionTitle)).ToArray();
        return mappedResults;
    }

    [HttpPost]
    public async Task<IActionResult> Post(JobApplicationCreateModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        if (!ModelState.IsValid)
            return CustomResponses.CreateBadRequestResult(["blah"]);

        var newId = await jobApplicationRepo.Insert(model.Map());

        return new OkObjectResult(new { newId });
    }
}
