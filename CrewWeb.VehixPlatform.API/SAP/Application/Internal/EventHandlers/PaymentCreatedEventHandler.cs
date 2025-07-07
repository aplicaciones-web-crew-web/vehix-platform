using ACME.LearningCenterPlatform.API.Shared.Application.Internal.EventHandlers;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.SAP.Application.Internal.EventHandlers;

public class PaymentCreatedEventHandler: IEventHandler<PaymentCreatedEvent>
{
    public Task Handle(PaymentCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    public Task On(PaymentCreatedEvent domainEvent)
    {
        Console.WriteLine("Created Payment: {0}", domainEvent.StatusId);
        return Task.CompletedTask;
    }
}