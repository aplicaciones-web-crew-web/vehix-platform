namespace CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;

public record SetDefaultVehicleResource(
    int UserId,
    int VehicleId
    );