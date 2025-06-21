using CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.Aggregates;
public class Payment
{
    public Guid Id { get; }
    public DateTime PaymentDate { get; }
    public Money Amount { get; }
    public string PaymentMethod { get; }
    public bool IsSuccessful { get; protected set; }

    public Payment(Guid id, DateTime paymentDate, Money amount, string paymentMethod, bool isSuccessful)
    {
        Id = id;
        PaymentDate = paymentDate;
        Amount = amount;
        PaymentMethod = paymentMethod;
        IsSuccessful = isSuccessful;
    }
    
    public void MarkAsSuccessful()
    {
        if (IsSuccessful)
            throw new InvalidOperationException("Payment is already successful.");

        IsSuccessful = true;
    }
    
    public void MarkAsFailed()
    {
        if (!IsSuccessful)
            throw new InvalidOperationException("Payment is already failed.");

        IsSuccessful = false;
    }
    public override string ToString()
    {
        return $"Payment Id: {Id}, Date: {PaymentDate}, Amount: {Amount.Amount} {Amount.Currency}, Method: {PaymentMethod}, Successful: {IsSuccessful}";
    }
}