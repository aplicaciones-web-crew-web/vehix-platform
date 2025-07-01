using System.Net.Mime;
using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.IAM.Domain.Services;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available User Endpoints")]
public class UsersController(
    IUserCommandService userCommandService,
    IUserQueryService userQueryService
) : ControllerBase
{
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        var user = await userQueryService.Handle(new GetUserByIdQuery(userId));
        if (user is null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userQueryService.Handle(new GetAllUsersQuery());
        var resources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserResource resource)
    {
        var command = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(command);
        if (user is null) return BadRequest();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = userResource.Id }, userResource);
    }
}