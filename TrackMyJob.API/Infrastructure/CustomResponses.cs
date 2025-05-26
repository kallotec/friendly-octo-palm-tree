using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TrackMyJob.API.Models;
namespace TrackMyJob.API.Infrastructure;

public static class CustomResponses
{
    public static IActionResult CreateBadRequestResult(string[] errors) => new BadRequestObjectResult(new ValidationErrorResultModel(errors));
}