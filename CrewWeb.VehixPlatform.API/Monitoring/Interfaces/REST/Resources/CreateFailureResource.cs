namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record CreateFailureResource(string SuggestSolution, int BadPracticeId, int ObdErrorId);