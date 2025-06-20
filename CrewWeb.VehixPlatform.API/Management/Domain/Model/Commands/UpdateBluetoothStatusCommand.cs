using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;

public record UpdateBluetoothStatusCommand(
    VehicleIdentifier VehicleId,
    Mileage NewMileage
    );