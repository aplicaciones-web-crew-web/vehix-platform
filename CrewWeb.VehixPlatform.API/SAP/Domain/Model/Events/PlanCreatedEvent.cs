using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Events;

public class PlanCreatedEvent(
    int planId,
    string planName,
    double price,
    string imageUrl
) : IEvent
{
    public int PlanId { get; } = planId;
    public string PlanName { get; } = planName;
    public double Price { get; } = price;
    public string ImageUrl { get; } = imageUrl;
}