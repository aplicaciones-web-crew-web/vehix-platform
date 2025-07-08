using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Transform;

public class VehicleResourceFromEntityAssembler
{
    public static VehicleResource ToResourceFromEntity(Vehicle entity)
    {
        return new VehicleResource(
            entity.Id,
            entity.UserId,
            entity.Description,
            entity.Name,
            entity.Brand,
            entity.Model,
            entity.Mileage,
            entity.Year,
            entity.ImageUrl
        );
    }
}