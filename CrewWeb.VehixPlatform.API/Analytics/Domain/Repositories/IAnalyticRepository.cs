using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Repositories;

public interface IAnalyticRepository : IBaseRepository<Analytic>
{
    Task<bool>ExistByVehicleId(int vehicleId);
    Task<Analytic?> GetByVehicleId(int vehicleId);
}