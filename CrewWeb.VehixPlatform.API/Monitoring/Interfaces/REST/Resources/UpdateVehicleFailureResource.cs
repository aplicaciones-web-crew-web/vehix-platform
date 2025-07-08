namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record UpdateVehicleFailureResource(
    int Id,
    int VehicleId,
    int FailureId,
    DateTime Date,
    string Status
);