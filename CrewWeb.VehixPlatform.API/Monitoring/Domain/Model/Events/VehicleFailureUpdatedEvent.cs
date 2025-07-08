using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;

public class VehicleFailureUpdatedEvent(
    int id,
    int vehicleId,
    int failureId,
    DateTime date,
    string status
): IEvent
{
    public int Id { get; } = id;
    public int VehicleId { get; } = vehicleId;
    public int FailureId { get; } = failureId;
    public DateTime Date { get; } = date;
    public string Status { get; } = status;
}