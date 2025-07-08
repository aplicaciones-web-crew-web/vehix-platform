using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace CrewWeb.VehixPlatform.API.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}