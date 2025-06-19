using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Queries;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IOdbErrorQueryService
{
    Task<OdbError?> Handle(GetObdErrorByIdQuery query);
    Task<IEnumerable<OdbError>> Handle(GetAllObdErrorsQuery query);
}