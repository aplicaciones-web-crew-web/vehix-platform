namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record AddOdbErrorToFailure(int OdbErrorId, int FailureId);