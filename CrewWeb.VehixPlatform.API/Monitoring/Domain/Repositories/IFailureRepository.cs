using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;

public interface IFailureRepository : IBaseRepository<Failure>
{
    Task<bool> ExistById(int id);
    
    Task<Failure?> FindByOdbErrorId(int odbErrorId);
}