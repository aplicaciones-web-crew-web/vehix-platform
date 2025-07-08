using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Transform;

public class CreateAnalyticCommandFromResourceAssembler
{
    public static CreateAnalyticCommand ToCommandFromResource(CreateAnalyticResource resource)
    {
        return new CreateAnalyticCommand(
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