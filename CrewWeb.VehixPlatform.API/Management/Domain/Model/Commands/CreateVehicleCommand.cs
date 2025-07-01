namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;

public record CreateVehicleCommand(
    string Description,
    string Name,
    string Brand,
    string Model,
    string Mileage,
    string Year,
    string ImageUrl
);