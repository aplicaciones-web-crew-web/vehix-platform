using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public class UpdateVehicleFailureCommandFromResourceAssembler
{
    public static UpdateVehicleFailureCommand ToCommandFromResource(UpdateVehicleFailureResource resource)
    {
        return new UpdateVehicleFailureCommand(
            resource.Id,
            resource.VehicleId,
            resource.FailureId,
            resource.Status,
            resource.Date == default ? DateTime.Now : resource.Date
        );
    }
}