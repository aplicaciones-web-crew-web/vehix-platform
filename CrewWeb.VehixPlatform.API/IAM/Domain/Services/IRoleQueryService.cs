using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.IAM.Domain.Services;

public interface IRoleQueryService
{
    Task<Role?> Handle(GetRoleByIdQuery query);
    Task<IEnumerable<Role>> Handle(GetAllRolesQuery query);
}