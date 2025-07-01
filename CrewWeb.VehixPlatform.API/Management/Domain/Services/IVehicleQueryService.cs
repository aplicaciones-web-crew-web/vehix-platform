using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Services;

public interface IVehicleQueryService
{
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query);
    Task<Vehicle?> Handle(GetVehicleByIdQuery query);
    Task<Vehicle?> Handle(GetVehiclesByUserIdQuery query);
    Task<Vehicle?> GetVehicleByIdAsync(int vehicleId);
    Task<object> GetAllVehiclesAsync();
}