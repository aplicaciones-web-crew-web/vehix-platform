using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByDniAsync(string dni);
}