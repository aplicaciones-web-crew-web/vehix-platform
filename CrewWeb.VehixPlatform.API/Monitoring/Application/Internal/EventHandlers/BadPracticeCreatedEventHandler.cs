using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Shared.Application.Internal.EventHandlers;
using Humanizer;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.EventHandlers;

public class BadPracticeCreatedEventHandler : IEventHandler<BadPracticeCreatedEvent>
{
    public Task Handle(BadPracticeCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    private Task On(BadPracticeCreatedEvent domainEvent)
    {
        Console.WriteLine("Created Bad Practice: {0}", domainEvent.DescriptionbadPractice);
        return Task.CompletedTask;
    }
}