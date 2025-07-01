using System.Net.Mime;
using CrewWeb.VehixPlatform.API.Management.Domain.Services;
using CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;
using CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Vehicle Endpoints")]
public class VehixControler : ControllerBase
{
    private readonly IVehicleCommandService _vehicleCommandService;
    private readonly IVehicleQueryService _vehicleQueryService;

    public VehixControler(
        IVehicleCommandService vehicleCommandService,
        IVehicleQueryService vehicleQueryService)
    {
        _vehicleCommandService = vehicleCommandService;
        _vehicleQueryService = vehicleQueryService;
    }

    [HttpGet("{vehicleId:int}")]
    public async Task<IActionResult> GetVehicleById(int vehicleId)
    {
        var vehicle = await _vehicleQueryService.GetVehicleByIdAsync(vehicleId);
        if (vehicle is null) return NotFound();
        var resource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles()
    {
        var vehicles = await _vehicleQueryService.GetAllVehiclesAsync();
        var vehicleResources = vehicles.Equals(VehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(vehicleResources);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleResource resource)
    {
        var createVehicleCommand = CreateVehicleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var vehicle = await _vehicleCommandService.CreateVehicleAsync(createVehicleCommand);
        if (vehicle is null) return BadRequest("Vehicle could not be created.");
        
        var createdResource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle);
        return CreatedAtAction(nameof(GetVehicleById), new { vehicleId = createdResource.Id }, createdResource);
    }
}