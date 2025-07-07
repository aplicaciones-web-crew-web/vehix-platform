using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.ASM.Domain.Model.Events;

public class VehicleCreatedEvent(
    int userId,
    string name,
    string brand,
    string model,
    int mileage,
    int year,
    string imageUrl
) : IEvent
{
}