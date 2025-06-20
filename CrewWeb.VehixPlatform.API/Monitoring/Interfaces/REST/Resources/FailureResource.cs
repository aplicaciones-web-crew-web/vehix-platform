namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record FailureResource(int Id, string SuggestSolution, BadPracticeResource BadPractice, OdbErrorResource OdbError, string FailureStatus, string FailureType, string FailureUrgency);