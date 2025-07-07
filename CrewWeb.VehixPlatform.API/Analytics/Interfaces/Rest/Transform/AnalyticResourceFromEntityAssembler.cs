using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.Analytics.Interfaces.Rest.Transform;

public class AnalyticResourceFromEntityAssembler
{
    public static AnalyticResource ToResourceFromEntity(Analytic entity)
    {
        return new AnalyticResource(
            entity.Id,
            entity.VehicleId,
            entity.Engine,
            entity.Transmission,
            entity.Brake,
            entity.Electrical,
            entity.Steering,
            entity.Suspension,
            entity.Fuel,
            entity.Refrigeration
        );
    }
}