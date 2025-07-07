namespace CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Resources;

public record AnalyticResource(
    int Id,
    int VehicleId,
    int Engine,
    int Transmission,
    int Brake,
    int Electrical,
    int Steering,
    int Suspension,
    int Fuel,
    int Refrigeration
    );