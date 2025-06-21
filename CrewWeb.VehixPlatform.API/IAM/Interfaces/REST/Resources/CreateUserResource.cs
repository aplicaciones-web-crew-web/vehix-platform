namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;

public record CreateUserResource(string Email, string PasswordHash, int RoleId);