using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.ASM.Domain.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<bool> ExistById(int id);
    Task<Vehicle?> GetById(int id);
    
    Task<IEnumerable<Vehicle>> GetByUserId(int userId);

}