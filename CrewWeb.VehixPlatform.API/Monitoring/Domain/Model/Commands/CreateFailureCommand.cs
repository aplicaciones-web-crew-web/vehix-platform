namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record CreateFailureCommand( int OdbErrorId, int BadPracticeId, string SuggestSolution);