using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Transform;

public class UpdateAnalyticCommandFromResourceAssembler
{
    public static UpdateAnalyticCommand ToCommandFromResource(UpdateAnalyticResource resource)
    {
        return new UpdateAnalyticCommand(
            resource.VehicleId,
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