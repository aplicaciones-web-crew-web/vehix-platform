using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Transform;

public static class SetDefaultVehicleCommandFromResourceAssembler
{
    public static SetDefaultVehicleCommand ToCommandFromResource(SetDefaultVehicleResource resource)
    {
        return new SetDefaultVehicleCommand(resource.UserId, resource.VehicleId);
    }
}