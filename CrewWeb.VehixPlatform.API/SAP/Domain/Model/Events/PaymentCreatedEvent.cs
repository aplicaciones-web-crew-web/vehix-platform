using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Events;

public class PaymentCreatedEvent(string status, DateTime date,decimal totalAmount):IEvent
{
    public string Status { get; } = status;
    public DateTime Date { get; } = date;
    public decimal TotalAmount { get; } = totalAmount;
}