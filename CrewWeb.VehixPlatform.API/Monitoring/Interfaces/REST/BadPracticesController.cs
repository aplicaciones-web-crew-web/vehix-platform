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
[SwaggerTag("Available Bad Practices Endpoints")]

public class BadPracticesController(
    IBadPracticeCommandService badPracticeCommandService,
    IBadPracticeQueryService badPracticeQueryService) : ControllerBase
{

    /// <summary>
    /// Gets a Bad Practice by its unique identifier.
    /// </summary>
    /// <param name="badPracticeId"></param>
    /// <returns></returns>
    [HttpGet("{badPracticeId:int}")]
    [SwaggerOperation(
        Summary = "Get Bad Practice by Id",
        Description = "Returns a Bad Practice by its unique identifier.",
        OperationId = "GetBadPracticeById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Category found", typeof(BadPracticeResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found")]
    public async Task<IActionResult> GetBadPracticeById(int badPracticeId)
    {
        var getBadPracticeByIdQuery = new GetBadPracticeByIdQuery(badPracticeId);
        var badPractice = await badPracticeQueryService.Handle(getBadPracticeByIdQuery);
        if (badPractice is null) return NotFound();
        var resource = BadPracticeResourceFromEntityAssembler.ToResourceFromEntity(badPractice);
        return Ok(resource);
    }

    /// <summary>
    /// Get All Bad Practices
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Bad Practices",
        Description = "Returns a list of all available BadPractices.",
        OperationId = "GetAllBadPractices")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of BadPractices", typeof(IEnumerable<BadPracticeResource>))]
    public async Task<IActionResult> GetAllBadPractices()
    {
        var badPractices = await badPracticeQueryService.Handle(new GetAllBadPracticesQuery());
        var badPracticeResources = badPractices
            .Select(BadPracticeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(badPracticeResources);
    }
    
    
    /// <summary>
    /// Creates a new Bad Practice and returns the created Bad Practice resource.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a New Bad Practice",
        Description = "Creates a new Bad Practice and returns the created Bad Practice resource.",
        OperationId = "CreateBadPractice")]
    [SwaggerResponse(StatusCodes.Status201Created, "Bad Practice created successfully", typeof(BadPracticeResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Category could not be created")]
    public async Task<IActionResult> CreateBadPractice([FromBody] CreateBadPracticeResource resource)
    {
        var createBadPracticeCommand = CreateBadPracticeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var badPractice = await badPracticeCommandService.Handle(createBadPracticeCommand);
        if (badPractice is null) return BadRequest("Bad Practice could not be created.");
        var badPracticeResource = BadPracticeResourceFromEntityAssembler.ToResourceFromEntity(badPractice);
        return CreatedAtAction(nameof(GetBadPracticeById), new { badPracticeId = badPracticeResource.Id }, badPracticeResource);
    }
    
}