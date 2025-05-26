using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace TrackMyJob.API.Infrastructure;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class ApiControllerBase : ControllerBase
{
}