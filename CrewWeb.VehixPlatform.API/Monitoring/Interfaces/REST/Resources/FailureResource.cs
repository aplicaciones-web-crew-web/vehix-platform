namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record FailureResource(
    int Id,
    string Title,
    string SuggestSolution,
    int BadPracticeId,
    int OdbErrorId,
    string Urgency
);