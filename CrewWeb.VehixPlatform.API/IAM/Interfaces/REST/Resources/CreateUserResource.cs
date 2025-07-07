namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;

public record CreateUserResource(
    string Name,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    string Dni,
    string Gender,
    int PlanId);