using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;

public record CreateVehicleCommand(int OwnerId, string Model, string Brand, int Year, string Plate, double Mileage, EFuelType FuelType);