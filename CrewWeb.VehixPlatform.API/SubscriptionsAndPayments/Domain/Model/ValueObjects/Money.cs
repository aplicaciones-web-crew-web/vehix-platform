namespace CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.ValueObjects;

public class Money
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}