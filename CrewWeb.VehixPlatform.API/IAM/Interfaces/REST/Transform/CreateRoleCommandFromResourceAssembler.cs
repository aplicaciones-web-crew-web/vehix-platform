using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Transform;

public static class CreateRoleCommandFromResourceAssembler
{
    public static CreateRoleCommand ToCommandFromResource(CreateRoleResource resource)
    {
        return new CreateRoleCommand(resource.Name);
    }
}