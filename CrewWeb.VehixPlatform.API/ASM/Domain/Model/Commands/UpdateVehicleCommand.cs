namespace CrewWeb.VehixPlatform.API.ASM.Domain.Model.Commands;

public record UpdateVehicleCommand(
    int UserId,
    string Name,
    string Brand,
    string Model,
    int Mileage,
    int Year,
    string ImageUrl
);