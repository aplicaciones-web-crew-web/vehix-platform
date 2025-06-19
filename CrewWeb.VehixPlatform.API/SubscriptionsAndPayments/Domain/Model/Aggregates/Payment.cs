using CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.Entities;

namespace CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.Aggregates;
public class Payment
{
    public Guid Id { get; }
    public DateTime PaymentDate { get; }
    public Money Amount { get; }
    public string PaymentMethod { get; }
    public bool IsSuccessful { get; }

    public Payment(Guid id, DateTime paymentDate, Money amount, string paymentMethod, bool isSuccessful)
    {
        Id = id;
        PaymentDate = paymentDate;
        Amount = amount;
        PaymentMethod = paymentMethod;
        IsSuccessful = isSuccessful;
    }
}