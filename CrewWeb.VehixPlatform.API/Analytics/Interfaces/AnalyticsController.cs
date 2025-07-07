using System.Net.Mime;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Services;
using CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Resources;
using CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.Analytics.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Analytics Endpoints")]
public class AnalyticsController(
    IAnalyticCommandService analyticCommandService,
    IAnalyticQueryService analyticQueryService) : ControllerBase
{
    [HttpGet("{analyticId:int}")]
    [SwaggerOperation(
        Summary = "Get Analytic by Id",
        Description = "Returns a Analytic by its unique identifier",
        OperationId = "GetAnalyticById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Analytic found", typeof(AnalyticResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Analytic not found")]
    public async Task<IActionResult> GetAnalyticById(int analyticId)
    {
        var getAnalyticByIdQuery = new GetAnalyticByIdQuery(analyticId);
        var analytic = await analyticQueryService.Handle(getAnalyticByIdQuery);
        if (analytic is null) return NotFound();
        var resource = AnalyticResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(resource);
    }

    [HttpGet("vehicle/{vehicleId:int}")]
    [SwaggerOperation(
        Summary = "Get Analytic by vehicle Id",
        Description = "Returns a Analytic by its vehicle identifier",
        OperationId = "GetAnalyticByVehicleId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Analytic found", typeof(AnalyticResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Analytic not found")]
    public async Task<IActionResult> GetAnalyticByVehicleId(int vehicleId)
    {
        var getAnalyticByVehicleIdQuery = new GetAnalyticByVehicleId(vehicleId);
        var analytic = await analyticQueryService.Handle(getAnalyticByVehicleIdQuery);
        if (analytic is null) return NotFound();
        var resource = AnalyticResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(resource);
    }


    [HttpGet("analytics")]
    [SwaggerOperation(
        Summary = "Get All Analytics",
        Description = "Returns a list of all Analytics.",
        OperationId = "GetAllAnalytics")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of Analytics", typeof(IEnumerable<AnalyticResource>))]
    public async Task<IActionResult> GetAllAnalytics()
    {
        var analytics = await analyticQueryService.Handle(new GetAllAnalyticsQuery());
        var analyticResources = analytics
            .Select(AnalyticResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(analyticResources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Analytic",
        Description = "Creates a new Analytic and returns the created Analytic Resource.",
        OperationId = "CreateAnalytic")]
    [SwaggerResponse(StatusCodes.Status201Created, "Analytic created successfully", typeof(AnalyticResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Analytic could not be created")]
    public async Task<IActionResult> CreateAnalytic([FromBody] CreateAnalyticResource resource)
    {
        var createAnalyticCommand =
            CreateAnalyticCommandFromResourceAssembler.ToCommandFromResource(resource);
        var analytic = await analyticCommandService.Handle(createAnalyticCommand);
        if (analytic is null) return BadRequest("Analytic could not be created.");
        var analyticResource = AnalyticResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return new CreatedResult(string.Empty, analyticResource);
    }

    [HttpPut]
    [SwaggerOperation(
        Summary = "Update a Analytic",
        Description = "Updates an existing Analytic and returns the updated Analytic Resource.",
        OperationId = "UpdateAnalytic")]
    [SwaggerResponse(StatusCodes.Status200OK, "Analytic updated successfully", typeof(AnalyticResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Analytic could not be updated")]
    public async Task<IActionResult> UpdateAnalytic([FromBody] UpdateAnalyticResource resource)
    {
        var updateAnalyticCommand =
            UpdateAnalyticCommandFromResourceAssembler.ToCommandFromResource(resource);
        var analytic = await analyticCommandService.Handle(updateAnalyticCommand);
        if (analytic is null) return BadRequest("Analytic could not be updated.");
        var analyticResource = AnalyticResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(analyticResource);
    }
}