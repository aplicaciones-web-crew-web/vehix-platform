namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record CreateFailureCommand(
    string Title,
    string SuggestSolution,
    int BadPracticeId,
    int OdbErrorId,
    string Urgency
);