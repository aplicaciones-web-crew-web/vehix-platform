namespace CrewWeb.VehixPlatform.API.Subscriptions_and_payments.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Subscriptions_and_payments.Domain.Model.ValueObjects;

public class Subscription
{
    public int Id { get; set; }
    
    public SubscriptionType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }

    public Subscription(int id, DateTime startDate,SubscriptionType type, DateTime endDate, bool isActive)
    {
        Id = id;
        Type = type;
        StartDate = startDate;
        EndDate = endDate;
        IsActive = isActive;
    }
    
    
    

    // Additional properties or methods can be added as needed
}