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
    public async Task<Plan> Handle(CreatePlanCommand command)
    {
        
        // Validate the plan Id exists in the repository
        if (!Enum.IsDefined(typeof(EPlan), command.PlanId))
            throw new GeneralException("The Plan Id must be valid", "VALIDATION");
        
        // Validate if the plan Id is within the valid range
        if (command.PlanId <= 0 || command.PlanId > 2)
            throw new ArgumentException("Plan ID must be 1 or 2.", nameof(command.PlanId));

        // Validate if the plan already exists
        var planExists = await planRepository.ExistById(command.PlanId);
        if (planExists) throw new GeneralException("The Plan already exists", "ALREADY_EXISTS");

        // Proccess the command to create a new plan
        var plan = new Plan(command);
        await planRepository.AddAsync(plan);
        await unitOfWork.CompleteAsync();

        // Publish the domain event for plan creation
        await domainEventPublisher.PublishAsync(new PlanCreatedEvent(
            plan.PlanId,
            plan.PlanName,
            plan.Price,
            plan.ImageUrl
        ));

        // Return the created plan
        return plan;
    }
}