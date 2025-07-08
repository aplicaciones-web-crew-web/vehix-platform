using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.EventHandlers;

public class VehicleFailureUpdatedEventHandler : IEventHandler<VehicleFailureUpdatedEvent>
{
    public Task Handle(VehicleFailureUpdatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    public Task On(VehicleFailureUpdatedEvent domainEvent)
    {
        Console.WriteLine("Vehicle Failure Updated: Id={0}, FailureId={1}, VehicleId={2}, Date={3}, Status={4}",
            domainEvent.Id,
            domainEvent.FailureId,
            domainEvent.VehicleId,
            domainEvent.Date,
            domainEvent.Status
        );
        return Task.CompletedTask;
    }
}