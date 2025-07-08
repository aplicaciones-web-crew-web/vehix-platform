using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Transform;

public static class RoleResourceFromEntityAssembler
{
    public static RoleResource ToResourceFromEntity(Role role)
    {
        return new RoleResource(role.Id, role.Name);
    }
}