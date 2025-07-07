using System.Net.Mime;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.ASM.Domain.Services;
using CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Resources;
using CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Vehicles Endpoints")]
public class VehiclesController(
    IVehicleCommandService vehicleCommandService,
    IVehicleQueryService vehicleQueryService
) : ControllerBase
{
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Get Vehicle by Id",
        Description = "Returns a Vehicle by its unique identifier",
        OperationId = "GetVehicleById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Vehicle found", typeof(VehicleResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Vehicle not found")]
    public async Task<IActionResult> GetVehicleById(int vehicleId)
    {
        var getVehicleByIdQuery = new GetVehicleByIdQuery(vehicleId);
        var vehicle = await vehicleQueryService.Handle(getVehicleByIdQuery);
        if (vehicle is null) return NotFound();
        var resource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle);
        return Ok(resource);
    }

    [HttpGet("users/{id:int}")]
    [SwaggerOperation(
        Summary = "Get All vehicle by UserId",
        Description = "Returns vehicles by UserId",
        OperationId = "GetVehiclesByVehicleId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Vehicles found", typeof(VehicleResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Vehicles not found")]
    public async Task<IActionResult> GetVehiclesByVehicleId(int userId)
    {
        var getAllVehiclesByUserIdQuery = new GetAllVehiclesByUserId(userId);
        var vehicles = await vehicleQueryService.Handle(getAllVehiclesByUserIdQuery);
        var vehiclesResources = vehicles.Select(VehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(vehiclesResources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Vehicle",
        Description = "Creates a new Vehicle and returns the created Vehicle Resource.",
        OperationId = "CreateVehicle")]
    [SwaggerResponse(StatusCodes.Status201Created, "Analytic created successfully", typeof(VehicleResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Analytic could not be created")]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleResource resource)
    {
        var createVehicleCommand =
            CreateVehicleResourceFromEntityAssembler.ToCommandFromResource(resource);
        var vehicle = await vehicleCommandService.Handle(createVehicleCommand);
        if (vehicle is null) return BadRequest("Vehicle could not be created.");
        var vehicleResource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle);
        return new CreatedResult(string.Empty, vehicleResource);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Update a Vehicle",
        Description = "Updates an existing Vehicle by its ID.",
        OperationId = "UpdateVehicle")]
    [SwaggerResponse(StatusCodes.Status200OK, "Vehicle updated successfully", typeof(VehicleResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Vehicle could not be updated")]
    public async Task<IActionResult> UpdateVehicle(int vehicleId, [FromBody] UpdateVehicleResource resource)
    {
        if (vehicleId != resource.Id)
            return BadRequest("Vehicle ID mismatch.");

        var updateVehicleCommand = UpdateVehicleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var newVehicle = await vehicleCommandService.Handle(updateVehicleCommand);
        if (newVehicle is null)
            return BadRequest("Vehicle could not be updated.");

        var vehicleResource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(newVehicle);
        return Ok(vehicleResource);
    }
}