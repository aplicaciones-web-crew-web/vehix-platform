using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;

public interface IFailureRepository : IBaseRepository<Failure>
{
    Task<IEnumerable<Failure>> FindByFailureIdAsync(int failureId);
}