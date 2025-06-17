namespace CrewWeb.VehixPlatform.API.Subscriptions_and_payments.Domain.Model.ValueObjects;


// <summary>
//     Represents a monetary value with an amount and currency
// </summary>
public class Money
{
    public decimal Amount { get; set;}
    public string Currency { get; set; }
}