using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;

public class FailureCreatedEvent(
    string title,
    string suggestSolution,
    int badPracticeId,
    int odbErrorId,
    string urgency
) : IEvent
{
    public string Title { get; } = title;
    public string SuggestSolution { get; } = suggestSolution;
    public int BadPracticeId { get; } = badPracticeId;
    public int OdbErrorId { get; } = odbErrorId;
    public string Urgency { get; } = urgency;
}