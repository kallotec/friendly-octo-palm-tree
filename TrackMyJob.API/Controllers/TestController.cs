using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace TrackMyJob.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<string[]> Get()
    {
        return await Task.FromResult(Array.Empty<string>()).ConfigureAwait(false);
    }
}
