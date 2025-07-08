using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;
using CrewWeb.VehixPlatform.API.SAP.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.SAP.Application.Internal.CommandServices;

public class PlanCommandService(
    IPlanRepository planRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher
) : IPlanCommandService
{
    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        // Validate the plan name exists in the repository
        if (!Enum.TryParse<EPlan>(command.Name, ignoreCase: true, out var ePlanValue))
            throw new GeneralException("The Plan must be valid (Standard or Pro).", "VALIDATION");

        var standardizedPlanName = new Plan(command.Name).Name;

        // Validate if the plan already exists
        var planExistsByName = await planRepository.ExistByName(standardizedPlanName);

        if (planExistsByName)
            throw new GeneralException($"A plan with the name '{standardizedPlanName}' already exists.",
                "ALREADY_EXISTS");


        // Proceed with plan creation
        var plan = new Plan(command);
        await planRepository.AddAsync(plan);
        await unitOfWork.CompleteAsync();

        // Publish the domain event for plan creation
        await domainEventPublisher.PublishAsync(new PlanCreatedEvent(
            plan.Id,
            plan.Name,
            plan.Price,
            plan.ImageUrl
        ));

        // Return the created plan
        return plan;
    }
}