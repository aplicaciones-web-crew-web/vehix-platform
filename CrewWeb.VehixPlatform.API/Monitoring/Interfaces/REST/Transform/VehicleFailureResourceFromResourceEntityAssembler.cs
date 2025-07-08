using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public class VehicleFailureResourceFromResourceEntityAssembler
{
    public static VehicleFailureResource ToResourceFromEntity(VehicleFailure entity)
    {
        return new VehicleFailureResource(
            entity.Id,
            entity.VehicleId,
            entity.FailureId,
            entity.Date,
            entity.Status
        );
    }
}