using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.IAM.Domain.Repositories;
using CrewWeb.VehixPlatform.API.IAM.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.IAM.Application.Internal.CommandServices;

public class RoleCommandService(
    IRoleRepository roleRepository,
    IUnitOfWork unitOfWork) : IRoleCommandService
{
    public async Task<Role?> Handle(CreateRoleCommand command)
    {
        var role = new Role(command);
        await roleRepository.AddAsync(role);
        await unitOfWork.CompleteAsync();
        return role;
    }
}