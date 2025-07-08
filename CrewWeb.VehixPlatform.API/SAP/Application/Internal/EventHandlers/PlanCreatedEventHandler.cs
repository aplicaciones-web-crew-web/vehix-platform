using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace CrewWeb.VehixPlatform.API.SAP.Application.Internal.EventHandlers;

public class PlanCreatedEventHandler : IEventHandler<PlanCreatedEvent>
{
    public Task Handle(PlanCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    public Task On(PlanCreatedEvent domainEvent)
    {
        Console.WriteLine("Created Plan: {0}", domainEvent.PlanName);
        return Task.CompletedTask;
    }
}