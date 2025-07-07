using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IFailureQueryService
{
    Task<Failure?> Handle(GetFailureByIdQuery query);
    Task<IEnumerable<Failure>> Handle(GetAllFailuresQuery query);
    
    Task<IEnumerable<Failure>> Handle(GetAllFailuresByErrorTypeQuery query);
}