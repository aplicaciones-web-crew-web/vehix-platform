using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;

public interface IVehicleFailureRepository : IBaseRepository<VehicleFailure>
{
    Task<IEnumerable<VehicleFailure>> FindByVehicleId(int vehicleId);
    Task<bool> ExistByVehicleId(int vehicleId);
    Task<bool> ExistById(int vehicleFailureId);
}