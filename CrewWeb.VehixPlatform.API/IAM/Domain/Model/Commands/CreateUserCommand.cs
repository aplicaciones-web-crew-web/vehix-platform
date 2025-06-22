namespace CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;

public record CreateUserCommand(
    string Name,
    string Lastname,
    string Email,
    string PasswordHash,
    string PhoneNumber,
    string Dni,
    string Gender,
    int PlanId,
    int RoleId);