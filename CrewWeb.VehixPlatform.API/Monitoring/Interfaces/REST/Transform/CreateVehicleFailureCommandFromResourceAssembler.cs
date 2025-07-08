using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public class CreateVehicleFailureCommandFromResourceAssembler
{
    public static CreateVehicleFailureCommand ToCommandFromResource(CreateVehicleFailureResource resource)
    {
        return new CreateVehicleFailureCommand(
            resource.VehicleId,
            resource.FailureId,
            resource.Status,
            resource.Date
        );
    }
}