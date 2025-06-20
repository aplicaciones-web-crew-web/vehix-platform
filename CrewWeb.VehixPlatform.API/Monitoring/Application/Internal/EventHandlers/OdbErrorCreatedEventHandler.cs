using ACME.LearningCenterPlatform.API.Shared.Application.Internal.EventHandlers;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.EventHandlers;

public class OdbErrorCreatedEventHandler : IEventHandler<OdbErrorCreatedEvent>
{
    public Task Handle(OdbErrorCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    private Task On(OdbErrorCreatedEvent domainEvent)
    {
        Console.WriteLine("Created ODB Error Code: {0}", domainEvent.ErrorCode);
        Console.WriteLine("Created ODB Error Title: {0}", domainEvent.ErrorCodeTitle);
        Console.WriteLine("Created ODB Error Type: {0}", domainEvent.ErrorCodeType);

        return Task.CompletedTask;
    }
}