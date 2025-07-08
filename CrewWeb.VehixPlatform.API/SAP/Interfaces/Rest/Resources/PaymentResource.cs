namespace CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Resources;

public record PaymentResource(
    int Id,
    int UserId,
    int PlanId,
    DateTime PaymentDate,
    int StatusId,
    double TotalAmount
);