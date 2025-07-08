using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;

public class VehicleFailureCreatedEvent(
    int vehicleId,
    int failureId,
    DateTime date,
    string status
    ) : IEvent
{
    
}