using CrewWeb.VehixPlatform.API.Management.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Repositories;

public interface IUserVehicleProfileRepository : IBaseRepository<UserVehicleProfile>
{
    Task<UserVehicleProfile> GetByUserIdAsync(int userId);
    
    Task<bool> ExistsAsync(int userId);
}