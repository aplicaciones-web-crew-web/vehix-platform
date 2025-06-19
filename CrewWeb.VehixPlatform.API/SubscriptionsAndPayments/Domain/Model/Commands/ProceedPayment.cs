namespace CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.Commands;

public record ProceedPayment(
    Guid PaymentId,
    decimal Amount,
    string Currency,
    string PaymentMethod
);