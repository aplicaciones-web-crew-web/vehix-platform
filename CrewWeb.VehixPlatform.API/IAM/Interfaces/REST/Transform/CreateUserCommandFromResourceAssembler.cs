using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(
            resource.Name,
            resource.Lastname,
            resource.Email,
            resource.PasswordHash,
            resource.PhoneNumber,
            resource.Dni,
            resource.Gender,
            resource.PlanId,
            resource.RoleId);
    }
}