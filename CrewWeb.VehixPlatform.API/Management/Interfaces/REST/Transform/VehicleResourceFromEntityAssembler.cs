using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Transform;

public class VehicleResourceFromEntityAssembler
{
    public static VehicleResource ToResourceFromEntity(Vehicle entity)
    {
        return new VehicleResource(
            entity.Id,
            entity.OwnerId.Id,
            entity.Specs.Model,
            entity.Specs.Brand,
            entity.Specs.Year,
            entity.FuelType.ToString(),
            entity.Plate.Value,
            entity.Mileage.Value
        );
    }
}