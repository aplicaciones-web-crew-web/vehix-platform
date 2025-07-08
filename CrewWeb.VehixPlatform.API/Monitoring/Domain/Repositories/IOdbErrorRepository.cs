using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;

public interface IOdbErrorRepository : IBaseRepository<OdbError>
{
    Task<bool> ExistById(int id);
    Task<bool> ExistByCode(string code);
    
}