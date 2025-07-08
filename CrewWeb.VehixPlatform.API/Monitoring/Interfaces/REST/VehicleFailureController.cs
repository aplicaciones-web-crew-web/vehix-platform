using System.Net.Mime;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/vehicles-failures")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Vehicle Failures Endpoints")]
public class VehicleFailureController(
    IVehicleFailureCommandService vehicleFailureCommandService,
    IVehicleFailureQueryService vehicleFailureQueryService
) : ControllerBase
{
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Get Vehicle Failure by Id",
        Description = "Returns a Vehicle Failure by its unique identifier.",
        OperationId = "GetVehicleFailureById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Odb Error found", typeof(VehicleFailureResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found")]
    public async Task<IActionResult> GetVehicleFailureById(int id)
    {
        var getVehicleFailureByIdQuery = new GetVehicleFailureById(id);
        var vehicleFailure = await vehicleFailureQueryService.Handle(getVehicleFailureByIdQuery);
        if (vehicleFailure is null) return NotFound();
        var resource = VehicleFailureResourceFromResourceEntityAssembler.ToResourceFromEntity(vehicleFailure);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Vehicle Failures",
        Description = "Returns a list of all Vehicle Failures.",
        OperationId = "GetAllVehicleFailures")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of Vehicle Failures", typeof(IEnumerable<VehicleFailureResource>))]
    public async Task<IActionResult> GetAllVehicleFailures()
    {
        var vehicleFailures = await vehicleFailureQueryService.Handle(new GetAllVehiclesFailures());
        var vehicleFailuresResources = vehicleFailures
            .Select(VehicleFailureResourceFromResourceEntityAssembler.ToResourceFromEntity);
        return Ok(vehicleFailuresResources);
    }

    [HttpGet("vehicles/{vehicleId:int}")]
    [SwaggerOperation(
        Summary = "Get Vehicle Failures by Vehicle Id",
        Description = "Returns a list of Vehicle Failures for a specific vehicle.",
        OperationId = "GetVehicleFailuresByVehicleId")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of Vehicle Failures", typeof(IEnumerable<VehicleFailureResource>))]
    public async Task<IActionResult> GetVehicleFailuresByVehicleId(int vehicleId)
    {
        var vehicleFailuresByVehicleId =
            await vehicleFailureQueryService.Handle(new GetVehicleFailuresByVehicleId(vehicleId));
        var vehicleFailuresByVehicleIdResources = vehicleFailuresByVehicleId
            .Select(VehicleFailureResourceFromResourceEntityAssembler.ToResourceFromEntity);
        return Ok(vehicleFailuresByVehicleIdResources);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Vehicle Failure",
        Description = "Creates a new Vehicle Failure and returns the created Vehicle Failure resource.",
        OperationId = "CreateVehicleFailure")]
    [SwaggerResponse(StatusCodes.Status201Created, "Vehicle Failure created successfully", typeof(VehicleFailureResource))]
    public async Task<IActionResult> CreateVehicleFailure([FromBody] CreateVehicleFailureResource resource)
    {
        var createVehicleFailureCommand = CreateVehicleFailureCommandFromResourceAssembler.ToCommandFromResource(resource);
        var vehicleFailure = await vehicleFailureCommandService.Handle(createVehicleFailureCommand);
        if (vehicleFailure is null) return BadRequest("Failed to create Vehicle Failure");
        var createdResource = VehicleFailureResourceFromResourceEntityAssembler.ToResourceFromEntity(vehicleFailure);
        return new CreatedResult(string.Empty, createdResource);
    }
}