namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record AddBadPracticeToFailureCommand(string DescriptionBadPractice, int FailureId);