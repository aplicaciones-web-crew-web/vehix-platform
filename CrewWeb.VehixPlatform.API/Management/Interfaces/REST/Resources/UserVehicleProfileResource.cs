namespace CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;

public record UserVehicleProfileResource(
    int Id,
    int UserId,
    string Subscription,
    IEnumerable<VehicleResource> Vehicles
    );