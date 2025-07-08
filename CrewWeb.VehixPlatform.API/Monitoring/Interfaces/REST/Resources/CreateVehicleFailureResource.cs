namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record CreateVehicleFailureResource(
    int VehicleId,
    int FailureId,
    DateTime Date,
    string Status
);