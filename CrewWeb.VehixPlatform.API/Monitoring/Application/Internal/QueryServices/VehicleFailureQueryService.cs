using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.QueryServices;

public class VehicleFailureQueryService(IVehicleFailureRepository vehicleFailureRepository)
    : IVehicleFailureQueryService
{
    public async Task<VehicleFailure?> Handle(GetVehicleFailureById query)
    {
        return await vehicleFailureRepository.FindByIdAsync(query.VehicleFailureId);
    }

    public async Task<IEnumerable<VehicleFailure>> Handle(GetAllVehiclesFailures query)
    {
        return await vehicleFailureRepository.ListAsync();
    }

    public async Task<IEnumerable<VehicleFailure>> Handle(GetVehicleFailuresByVehicleId query)
    {
        return await vehicleFailureRepository.FindByVehicleId(query.VehicleId);
    }
}