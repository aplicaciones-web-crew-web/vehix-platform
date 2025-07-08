namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Commands;

public record UpdateAnalyticCommand(
    int AnalyticId,
    int Engine,
    int Transmission,
    int Brake,
    int Electrical,
    int Steering,
    int Suspension,
    int Fuel,
    int Refrigeration
);