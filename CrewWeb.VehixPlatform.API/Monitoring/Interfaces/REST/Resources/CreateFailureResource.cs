namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record CreateFailureResource(
    string Title, 
    string SuggestSolution,
    int BadPracticeId,
    int ObdErrorId,
    string Urgency
    );