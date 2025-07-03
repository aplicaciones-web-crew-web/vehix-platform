namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;

public record CreatePaymentCommand(
    int UserId,
    int PlanId,
    decimal AdditionalAmount,
    DateTime PaymentDate,
    int TotalAmount,
    string Status
);