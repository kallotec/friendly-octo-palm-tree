using Microsoft.AspNetCore.Mvc;
using TrackMyJob.API.Infrastructure;
using TrackMyJob.API.Models;
using TrackMyJob.Domain.Repos;
namespace TrackMyJob.API.Controllers;

[Route("api/[controller]")]
public class ApplicationsController(IJobApplicationRepo jobApplicationRepo) 
        : ApiControllerBase
{
    [HttpGet]
    public async Task<JobApplicationViewModel[]> GetAll()
    {
        var results = await jobApplicationRepo.GetAll();
        var mappedResults = results.Select(r => new JobApplicationViewModel(r.Id!, r.CompanyName, r.PositionTitle)).ToArray();
        return mappedResults;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await jobApplicationRepo.GetById(id);
        if (result == null)
            return base.NotFound();

        var mappedResults = JobApplicationViewModel.Map(result);
        return new JsonResult(mappedResults);
    }

    [HttpPost]
    public async Task<IActionResult> Post(JobApplicationCreateModel model)
    {
        ArgumentNullException.ThrowIfNull(model);
        var id = await jobApplicationRepo.Insert(model.Map());

        return base.CreatedAtAction(nameof(GetById), new { id }, new { id });
    }
}
