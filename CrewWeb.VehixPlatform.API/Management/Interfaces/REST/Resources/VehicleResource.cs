namespace CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;

public record VehicleResource(
    int Id,
    int OwnerId,
    string Model,
    string Brand,
    int Year,
    string FuelType,
    string Plate,
    double Mileage
    );