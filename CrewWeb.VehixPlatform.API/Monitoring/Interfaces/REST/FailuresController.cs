using System.Net.Mime;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Failure Endpoints")]
[Tags("Failures")]
public class FailuresController(
    IFailureCommandService failureCommandService,
    IFailureQueryService failureQueryService
) : ControllerBase
{
    /// <summary>
    /// Get a Failure by its unique identifier.
    /// </summary>
    /// <param name="failureId"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Get Failure by Id",
        Description = "Returns a failure by its unique identifier.",
        OperationId = "GetFailureById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Failure found", typeof(FailureResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Failure not found")]
    public async Task<IActionResult> GetFailureById([FromRoute] int failureId)
    {
        var failure = await failureQueryService.Handle(new GetFailureByIdQuery(failureId));
        if (failure is null) return NotFound();
        var resource = FailureResourceFromEntityAssembler.ToResourceFromEntity(failure);
        return Ok(resource);
    }

    /// <summary>
    /// Get All Failures
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Failures",
        Description = "Returns a list of all available failures.",
        OperationId = "GetAllFailures")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of failures", typeof(IEnumerable<FailureResource>))]
    public async Task<IActionResult> GetAllFailures()
    {
        var failures = await failureQueryService.Handle(new GetAllFailuresQuery());
        var failureResources = failures
            .Select(FailureResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(failureResources);
    }


    /// <summary>
    /// Create a New Failure instance
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a New Failure",
        Description = "Creates a new Failure and returns the created failure resource.",
        OperationId = "CreateFailure")]
    [SwaggerResponse(StatusCodes.Status201Created, "Failure created successfully", typeof(FailureResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Failure could not be created")]
    public async Task<IActionResult> CreateFailure([FromBody] CreateFailureResource resource)
    {
        var createFailureCommand = CreateFailureCommandFromResourceAssembler.ToCommandFromResource(resource);
        var failure = await failureCommandService.Handle(createFailureCommand);
        if (failure is null) return BadRequest("Failure could not be created.");
        var createdResource = FailureResourceFromEntityAssembler.ToResourceFromEntity(failure);
        return CreatedAtAction(nameof(GetFailureById), new { failureId = createdResource.Id }, createdResource);
    }

    [HttpGet("{error-type}/failures")]
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