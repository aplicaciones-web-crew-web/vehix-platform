namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record AddOdbErrorToFailureCommand(string ErrorCode, string ErrorCodeTitle, string ErrorType, int FailureId);