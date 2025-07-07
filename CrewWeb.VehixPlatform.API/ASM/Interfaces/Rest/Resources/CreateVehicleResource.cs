namespace CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Resources;

public record CreateVehicleResource(
    int UserId,
    string Description,
    string Name,
    string Brand,
    string Model,
    int Mileage,
    int Year,
    string ImageUrl
);