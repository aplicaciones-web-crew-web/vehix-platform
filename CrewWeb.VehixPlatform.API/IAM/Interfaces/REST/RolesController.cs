using System.Net.Mime;
using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.IAM.Domain.Services;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/roles")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Roles Endpoints")]
public class RolesController(
    IRoleCommandService roleCommandService,
    IRoleQueryService roleQueryService) : ControllerBase
{
    [HttpGet("{roleId:int}")]
    [SwaggerOperation(
        Summary = "Get Role by Id",
        Description = "Returns a role by its unique identifier.",
        OperationId = "GetRoleById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Role found", typeof(RoleResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Role not found")]
    public async Task<IActionResult> GetRoleById([FromRoute] int roleId)
    {
        var role = await roleQueryService.Handle(new GetRoleByIdQuery(roleId));
        if (role is null) return NotFound();
        var resource = RoleResourceFromEntityAssembler.ToResourceFromEntity(role);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Roles",
        Description = "Returns a list of all roles.",
        OperationId = "GetAllRoles")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of roles", typeof(IEnumerable<RoleResource>))]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await roleQueryService.Handle(new GetAllRolesQuery());
        var resources = roles.Select(RoleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Role",
        Description = "Creates a new role and returns the created role resource.",
        OperationId = "CreateRole")]
    [SwaggerResponse(StatusCodes.Status201Created, "Role created successfully", typeof(RoleResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Role could not be created")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleResource resource)
    {
        var command = CreateRoleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var role = await roleCommandService.Handle(command);
        if (role is null) return BadRequest("Role could not be created.");
        var roleResource = RoleResourceFromEntityAssembler.ToResourceFromEntity(role);
        return CreatedAtAction(nameof(GetRoleById), new { roleId = roleResource.Id }, roleResource);
    }
}