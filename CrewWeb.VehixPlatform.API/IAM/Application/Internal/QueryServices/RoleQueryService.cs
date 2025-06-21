using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.IAM.Domain.Repositories;
using CrewWeb.VehixPlatform.API.IAM.Domain.Services;

namespace CrewWeb.VehixPlatform.API.IAM.Application.Internal.QueryServices;

public class RoleQueryService(IRoleRepository roleRepository) : IRoleQueryService
{
    public async Task<Role?> Handle(GetRoleByIdQuery query)
    {
        return await roleRepository.FindByIdAsync(query.RoleId);
    }

    public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery query)
    {
        return await roleRepository.ListAsync();
    }
}