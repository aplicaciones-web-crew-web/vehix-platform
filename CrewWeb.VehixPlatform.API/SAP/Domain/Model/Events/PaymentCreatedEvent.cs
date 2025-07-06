using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Events;

public class PaymentCreatedEvent(
    int userId,
    int planId,
    double scannerAmount,
    double planAmount,
    double shipmentAmount,
    double subtotalAmount,
    double totalAmount,
    DateTime date,
    int statusId
) : IEvent
{
    public int PlanId { get; } = planId;
    public int UserId { get; } = userId;
    public double ScannerAmount { get; } = scannerAmount;
    public double PlanAmount { get; } = planAmount;
    public double ShipmentAmount { get; } = shipmentAmount;
    public double SubtotalAmount { get; } = subtotalAmount;
    public double TotalAmount { get; } = totalAmount;
    public DateTime PaymentDate { get; } = date;
    public int StatusId { get; } = statusId;
}