using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Transform;

public static class UpdateAnalyticByVehicleIdCommandFromResourceAssembler
{
    public static UpdateAnalyticByVehicleIdCommand ToCommandFromResource(int vehicleId,
        UpdateAnalyticByVehicleIdResource resource)
    {
        return new UpdateAnalyticByVehicleIdCommand(
            vehicleId,
            resource.Engine,
            resource.Transmission,
            resource.Brake,
            resource.Electrical,
            resource.Steering,
            resource.Suspension,
            resource.Fuel,
            resource.Refrigeration
        );
    }
}