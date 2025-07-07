namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record CreateVehicleFailureCommand(
    int VehicleId,
    int FailureId,
    string Status,
    DateTime Date = new DateTime()
);