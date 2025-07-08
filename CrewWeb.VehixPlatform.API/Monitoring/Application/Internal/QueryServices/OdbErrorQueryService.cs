using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.QueryServices;

public class OdbErrorQueryService(IOdbErrorRepository odbErrorRepository) : IOdbErrorQueryService
{
    public async Task<OdbError?> Handle(GetOdbErrorById query)
    {
        return await odbErrorRepository.FindByIdAsync(query.OdbErrorId);
    }

    public async Task<IEnumerable<OdbError>> Handle(GetAllOdbErrors query)
    {
        return await odbErrorRepository.ListAsync();
    }
}