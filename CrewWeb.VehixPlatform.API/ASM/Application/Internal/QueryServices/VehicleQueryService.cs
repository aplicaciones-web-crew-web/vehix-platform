using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.ASM.Domain.Repositories;
using CrewWeb.VehixPlatform.API.ASM.Domain.Services;

namespace CrewWeb.VehixPlatform.API.ASM.Application.Internal.QueryServices;

public class VehicleQueryService(IVehicleRepository vehicleRepository) : IVehicleQueryService
{
    public async Task<Vehicle?> Handle(GetVehicleByIdQuery query)
    {
        return await vehicleRepository.FindByIdAsync(query.VehicleId);
    }

    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query)
    {
        return await vehicleRepository.ListAsync();
    }

    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesByUserId query)
    {
        return await vehicleRepository.FindByUserId(query.UserId);
    }
}