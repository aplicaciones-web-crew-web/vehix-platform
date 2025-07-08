using ACME.LearningCenterPlatform.API.Shared.Application.Internal.EventHandlers;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.Analytics.Application.Internal.EventHandlers;

public class AnalyticCreatedEventHandler : IEventHandler<AnalyticCreatedEvent>
{
    public Task Handle(AnalyticCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    public Task On(AnalyticCreatedEvent domainEvent)
    {
        Console.WriteLine("Created Analytic: {0}", domainEvent.VehicleId);
        return Task.CompletedTask;
    }
}