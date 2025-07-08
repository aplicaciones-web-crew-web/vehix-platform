using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace CrewWeb.VehixPlatform.API.Analytics.Application.Internal.EventHandlers;

public class AnalyticUpdatedEventHandler : IEventHandler<AnalyticUpdatedByVehicleIdEvent>
{
    public Task Handle(AnalyticUpdatedByVehicleIdEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    public Task On(AnalyticUpdatedByVehicleIdEvent domainEvent)
    {
        Console.WriteLine("Updated Analytic: {0}", domainEvent.VehicleId);
        return Task.CompletedTask;
    }
}