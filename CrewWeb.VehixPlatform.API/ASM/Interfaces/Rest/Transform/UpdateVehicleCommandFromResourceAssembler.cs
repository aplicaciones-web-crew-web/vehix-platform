using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Transform;

public class UpdateVehicleCommandFromResourceAssembler
{
    public static UpdateVehicleCommand ToCommandFromResource(UpdateVehicleResource resource)
    {
        return new UpdateVehicleCommand(
            resource.UserId,
            resource.Description,
            resource.Name,
            resource.Brand,
            resource.Model,
            resource.Mileage,
            resource.Year,
            resource.ImageUrl
        );
    }
}