using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Shared.Application.Internal.EventHandlers;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.EventHandlers;

public class FailureCreatedEventHandler : IEventHandler<FailureCreatedEvent>
{
    public Task Handle(FailureCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    private Task On(FailureCreatedEvent domainEvent)
    {
        Console.WriteLine("Created Failure: {0}", domainEvent.BadPracticeId);
        return Task.CompletedTask;
    }
}