using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace CrewWeb.VehixPlatform.API.ASM.Application.Internal.EventHandlers;

public class VehicleUpdatedEventHandler : IEventHandler<VehicleUpdatedEvent>
{
    public Task Handle(VehicleUpdatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    public Task On(VehicleUpdatedEvent domainEvent)
    {
        Console.WriteLine("Vehicle Updated: Id={0}, Name={1}, Brand={2}, Mileage={3}",
            domainEvent.Id,
            domainEvent.Name,
            domainEvent.Brand,
            domainEvent.Mileage
        );
        return Task.CompletedTask;
    }
}