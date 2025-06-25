using CrewWeb.VehixPlatform.API.Management.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Resources;
using CrewWeb.VehixPlatform.API.Management.Interfaces.REST.Transform;

namespace CrewWeb.VehixPlatform.API.Management.Services.REST.Transform;

public static class UserVehicleProfileResourceFromEntityAssembler
{
    public static UserVehicleProfileResource ToResourceFromEntity(UserVehicleProfile entity)
    {
        var vehicleResource = entity.Vehicles
            .Select(VehicleResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();
        return new UserVehicleProfileResource(
            entity.Id,
            entity.UserId.Id,
            entity.Subscription.ToString(),
            vehicleResource
        );
    }
}