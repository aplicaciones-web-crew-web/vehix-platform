namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Events;

public class AnalyticCreatedEvent(
    int vehicleId,
    int engine,
    int transmission,
    int brake,
    int electrical,
    int steering,
    int suspension,
    int fuel,
    int refrigeration
)
{
    public int VehicleId { get; } = vehicleId;
    public int Engine { get; } = engine;
    public int Transmission { get; } = transmission;
    public int Brake { get; } = brake;
    public int Electrical { get; } = electrical;
    public int Steering { get; } = steering;
    public int Suspension { get; } = suspension;
    public int Fuel { get; } = fuel;
    public int Refrigeration { get; } = refrigeration;
}