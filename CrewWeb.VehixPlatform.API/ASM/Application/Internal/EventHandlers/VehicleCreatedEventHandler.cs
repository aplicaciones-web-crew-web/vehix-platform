using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace CrewWeb.VehixPlatform.API.ASM.Application.Internal.EventHandlers;

public class VehicleCreatedEventHandler : IEventHandler<VehicleCreatedEvent>
{
    public Task Handle(VehicleCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    public Task On(VehicleCreatedEvent domainEvent)
    {
        Console.WriteLine("Created Vehicle: {0}", domainEvent.Description);
        return Task.CompletedTask;
    }
}