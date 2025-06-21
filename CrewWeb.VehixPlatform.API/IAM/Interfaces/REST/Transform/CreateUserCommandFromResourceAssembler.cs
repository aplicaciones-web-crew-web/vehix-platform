using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(resource.Email, resource.PasswordHash, resource.RoleId);
    }
}