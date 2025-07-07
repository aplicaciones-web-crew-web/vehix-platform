namespace CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Resources;

public record UpdateVehicleResource(
    int UserId,
    string Description,
    string Name,
    string Brand,
    string Model,
    int Mileage,
    int Year,
    string ImageUrl
);