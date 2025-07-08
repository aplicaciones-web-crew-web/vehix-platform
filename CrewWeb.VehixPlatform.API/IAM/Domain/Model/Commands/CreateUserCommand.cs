namespace CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;

public record CreateUserCommand(
    string Name,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    string Dni,
    string Gender,
    int PlanId);