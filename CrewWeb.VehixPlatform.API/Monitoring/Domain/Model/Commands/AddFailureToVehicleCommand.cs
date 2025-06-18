namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record AddFailureToVehicleCommand(int VehicleId, string ErrorCode);