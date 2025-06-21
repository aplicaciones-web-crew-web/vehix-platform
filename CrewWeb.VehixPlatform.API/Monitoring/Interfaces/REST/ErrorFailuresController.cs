using System.Net.Mime;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/errors/{errorType}/failures")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Errors")]
public class ErrorFailuresController(IFailureQueryService failureQueryService):ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get Failures by Error Type",
        Description = "Returns a list of failures associated with a specific error type",
        OperationId = "GetFailuresByErrorType")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of failures", typeof(IEnumerable<FailureResource>))]
    public async Task<IActionResult> GetFailuresByErrorType(string errorType)
    {
        var getAllFailuresByErrorTypeQuery = new GetAllFailuresByErrorTypeQuery(errorType);
        var failures = await failureQueryService.Handle(getAllFailuresByErrorTypeQuery);
        var failureResources = failures.Select(FailureResourceFromEntityAssembler.ToResourceFromEntity);
       return Ok(failureResources); 
    }
    
}