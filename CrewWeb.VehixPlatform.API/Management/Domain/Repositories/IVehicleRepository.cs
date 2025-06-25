using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> FindByUserIdAsync(int userId);

    Task<bool> ExistsByPlateAsync(string plate);
}