namespace CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.ValueObjects;
public class Subscription
{
    public Guid Id { get; }
    public SubscriptionType Type { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public bool IsActive { get; protected set; }

    public Subscription(Guid id, DateTime startDate, SubscriptionType type, DateTime endDate, bool isActive)
    {
        Id = id;
        Type = type;
        StartDate = startDate;
        EndDate = endDate;
        IsActive = isActive;
    }
    public void Activate()
    {
        if (IsActive && StartDate <= DateTime.UtcNow && EndDate >= DateTime.UtcNow)
            throw new InvalidOperationException("Subscription is already active.");

        IsActive = true;
    }
    
    public void Deactivate()
    {
        if (!IsActive || StartDate > DateTime.UtcNow || EndDate < DateTime.UtcNow)
            throw new InvalidOperationException("Subscription is already inactive.");

        IsActive = false;
    }
    
    
}