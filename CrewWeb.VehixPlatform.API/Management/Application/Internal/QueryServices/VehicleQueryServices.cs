using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Management.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Management.Domain.Services;

namespace CrewWeb.VehixPlatform.API.Management.Application.Internal.QueryServices;

public class VehicleQueryServices(IVehicleRepository vehicleRepository) : IVehicleQueryService
{
    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query)
    {
        return await vehicleRepository.ListAsync();
    }

    public async Task<Vehicle?> Handle(GetVehicleByIdQuery query)
    {
        return await vehicleRepository.FindByIdAsync(query.VehicleId);
    }

    public async Task<Vehicle?> Handle(GetVehiclesByUserIdQuery query)
    {
        return await vehicleRepository.FindByIdAsync(query.UserId);
    }

    public async Task<Vehicle?> GetVehicleByIdAsync(int vehicleId)
    {
        return await vehicleRepository.FindByIdAsync(vehicleId);
    }

    public async Task<object> GetAllVehiclesAsync()
    {
       return await vehicleRepository.ListAsync();
    }
}