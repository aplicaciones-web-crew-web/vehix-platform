namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record CreateOdbErrorCommand(
    string ErrorCode,
    string ErrorCodeTitle,
    string ErrorType
);