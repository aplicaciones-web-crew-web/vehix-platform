using System.Net.Mime;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.SAP.Domain.Services;
using CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Resources;
using CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.SAP.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Plans Endpoints")]
public class PlansController(
    IPlanCommandService planCommandService,
    IPlanQueryService planQueryService) : ControllerBase
{
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Get Plan by Id",
        Description = "Returns a plan by its unique identifier",
        OperationId = "GetPlanById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Plan found", typeof(PlanResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Plan not found")]
    public async Task<IActionResult> GetPlanById(int planId)
    {
        var getPlanByIdQuery = new GetPlanByIdQuery(planId);
        var plan = await planQueryService.Handle(getPlanByIdQuery);
        if (plan is null) return NotFound();
        var resource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return Ok(resource);
    }
    
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Plans",
        Description = "Returns a list of all Plans.",
        OperationId = "GetAllPlans")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of plans", typeof(IEnumerable<PlanResource>))]
    public async Task<IActionResult> GetAllPlans()
    {
        var plans = await planQueryService.Handle(new GetAllPlansQuery());
        var planResources = plans
            .Select(PlanResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(planResources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Plan",
        Description = "Creates a new Plan and returns the created Plan Resource.",
        OperationId = "CreatePlan")]
    [SwaggerResponse(StatusCodes.Status201Created, "Plan created successfully", typeof(PlanResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Plan could not be created")]
    public async Task<IActionResult> CreatePlan([FromBody] CreatePlanResource resource)
    {
        var createPlanCommand =
            CreatePlanCommandFromResourceAssembler.ToCommandFromResource(resource);
        var plan = await planCommandService.Handle(createPlanCommand);
        if (plan is null) return BadRequest("Plan could not be created.");
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return new CreatedResult(string.Empty, planResource);
    }
    
}