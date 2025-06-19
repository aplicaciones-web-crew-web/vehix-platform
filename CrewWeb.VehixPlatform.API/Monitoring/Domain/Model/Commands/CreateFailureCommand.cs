namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record CreateFailureCommand(int VehicleId, int OdbErrorId, int BadPracticeId, string SuggestSolution);