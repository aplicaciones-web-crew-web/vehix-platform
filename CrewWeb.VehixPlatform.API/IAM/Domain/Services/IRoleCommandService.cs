using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.IAM.Domain.Services;

public interface IRoleCommandService
{
    Task<Role?> Handle(CreateRoleCommand command);
}