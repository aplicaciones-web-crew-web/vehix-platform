namespace CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.ValueObjects;
public class Subscription
{
    public Guid Id { get; }
    public SubscriptionType Type { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public bool IsActive { get; }

    public Subscription(Guid id, DateTime startDate, SubscriptionType type, DateTime endDate, bool isActive)
    {
        Id = id;
        Type = type;
        StartDate = startDate;
        EndDate = endDate;
        IsActive = isActive;
    }
    
    
}