using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Transform;

public static class CreateVehicleCommandFromResourceAssembler
{
    public static CreateVehicleCommand ToCommandFromResource(CreateVehicleResource resource)
    {
        return new CreateVehicleCommand(
            resource.OwnerId,
            resource.Model, 
            resource.Brand,
            resource.Year,
            resource.Plate,
            resource.Mileage,
            Enum.Parse<EFuelType>(resource.FuelType)
            );
    }
}