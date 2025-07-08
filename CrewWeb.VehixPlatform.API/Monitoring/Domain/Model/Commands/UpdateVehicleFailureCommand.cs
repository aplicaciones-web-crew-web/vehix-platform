namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record UpdateVehicleFailureCommand(
    int Id,
    int VehicleId,
    int FailureId,
    DateTime Date,
    string Status
);