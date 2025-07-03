using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;

public class Payment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlanId { get; set; }

    public decimal AdditionalAmount { get; set; }

    public DateTime PaymentDate { get; set; }
    public EPaymentStatus Status { get; set; }
    public string StatusString { get; set; }
    public decimal TotalAmount { get; set; }


    public Payment(int userId, int planId, decimal additionalAmount, DateTime paymentDate,
        string statusString, decimal totalAmount)
    {
        UserId = userId;
        PlanId = planId;
        AdditionalAmount = additionalAmount;
        PaymentDate = paymentDate;
        TotalAmount = totalAmount;
        StatusString = statusString;
    }

    public Payment(CreatePaymentCommand command) : this(command.UserId, command.PlanId, command.AdditionalAmount,
        command.PaymentDate, command.Status, command.TotalAmount)
    {
    }
}