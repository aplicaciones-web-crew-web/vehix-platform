using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;

public record RegisterVehicleCommand(
    VehicleSpecs Specs,
    UserId UserId,
    EVehicleFuelType FuelType,
    Mileage Mileage,
    EVehicleStatus Status
    );