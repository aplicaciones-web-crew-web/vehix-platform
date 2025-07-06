using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;

public interface IPlanRepository : IBaseRepository<Plan>
{
    Task<bool> ExistById(int id);

}