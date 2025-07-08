using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IOdbErrorQueryService
{
    Task<OdbError?> Handle(GetOdbErrorById query);
    Task<IEnumerable<OdbError>> Handle(GetAllOdbErrors query);
}