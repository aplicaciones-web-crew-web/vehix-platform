namespace CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;

public record CreateVehicleResource(
    int OwnerId,
    string Model,
    string Brand,
    int Year,
    string FuelType,
    string Plate,
    int Mileage
    );