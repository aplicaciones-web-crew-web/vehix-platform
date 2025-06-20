using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;

public class OdbErrorCreatedEvent(string errorCode, string errorCodeTitle, string errorCodeType) : IEvent
{
    
}