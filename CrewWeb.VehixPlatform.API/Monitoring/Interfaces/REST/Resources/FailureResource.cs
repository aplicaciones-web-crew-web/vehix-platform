namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record FailureResource(
    int Id,
    string Title,
    string SuggestSolution,
    BadPracticeResource BadPractice,
    OdbErrorResource OdbError,
    string FailureType,
    string FailureUrgency);