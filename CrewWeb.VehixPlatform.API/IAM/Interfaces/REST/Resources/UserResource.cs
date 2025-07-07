namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;

public record UserResource(
    int Id,
    string Name,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    string Dni,
    string Gender,
    int PlanId);