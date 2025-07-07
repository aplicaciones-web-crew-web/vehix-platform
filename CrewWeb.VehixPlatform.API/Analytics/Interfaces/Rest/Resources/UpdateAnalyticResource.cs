namespace CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Resources;

public record UpdateAnalyticResource(
    int Engine,
    int Transmission,
    int Brake,
    int Electrical,
    int Steering,
    int Suspension,
    int Fuel,
    int Refrigeration
);