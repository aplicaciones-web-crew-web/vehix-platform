namespace CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;

public record CreateUserCommand(string Email, string PasswordHash, int RoleId);