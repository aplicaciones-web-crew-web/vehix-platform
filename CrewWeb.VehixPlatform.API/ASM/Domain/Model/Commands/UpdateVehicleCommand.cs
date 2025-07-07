namespace CrewWeb.VehixPlatform.API.ASM.Domain.Model.Commands;

public record UpdateVehicleCommand(
    int Id,
    int UserId,
    string Description,
    string Name,
    string Brand,
    string Model,
    int Mileage,
    int Year,
    string ImageUrl
);