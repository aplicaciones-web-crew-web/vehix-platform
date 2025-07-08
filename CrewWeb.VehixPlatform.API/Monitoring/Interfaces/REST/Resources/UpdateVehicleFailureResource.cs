namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record UpdateVehicleFailureResource(
    int Id,
    int VehicleId,
    int FailureId,
    string Status,
    DateTime Date = new DateTime()

);