namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record AddBadPracticeToFailure(int BadPracticeId, int FailureId);