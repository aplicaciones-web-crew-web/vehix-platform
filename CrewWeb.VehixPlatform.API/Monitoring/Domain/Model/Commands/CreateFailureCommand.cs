namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record CreateFailureCommand(int ObdErrorId, string obdErrorCode, string SugestSolution);