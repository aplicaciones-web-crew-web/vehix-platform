using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.ASM.Interfaces.Rest.Transform;

public class CreateVehicleResourceFromEntityAssembler
{
    public static CreateVehicleCommand ToCommandFromResource(CreateVehicleResource resource)
    {
        return new CreateVehicleCommand(
            resource.UserId,
            resource.Name,
            resource.Description,
            resource.Brand,
            resource.Model,
            resource.Mileage,
            resource.Year,
            resource.ImageUrl
        );
    }
}