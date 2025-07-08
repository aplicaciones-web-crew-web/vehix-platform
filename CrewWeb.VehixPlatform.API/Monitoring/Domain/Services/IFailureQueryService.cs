using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IFailureQueryService
{
    Task<Failure?> Handle(GetFailureById query);
    Task<IEnumerable<Failure>> Handle(GetAllFailures query);
}