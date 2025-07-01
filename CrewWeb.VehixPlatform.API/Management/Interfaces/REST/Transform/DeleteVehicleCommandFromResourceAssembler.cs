using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Transform;

public static class DeleteVehicleCommandFromResourceAssembler
{
    public static DeleteVehicleCommand ToCommandFromResource(DeleteVehicleResource resource)
    {
        return new DeleteVehicleCommand(resource.VehicleId);
    }
}