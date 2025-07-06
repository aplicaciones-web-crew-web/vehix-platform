using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;

public partial class Payment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlanId { get; set; }

    public double ScannerAmount { get; set; }
    public double PlanAmount { get; set; }
    public double ShipmentAmount { get; set; }
    public double SubtotalAmount { get; set; }
    public double TotalAmount { get; set; }

    public DateTime PaymentDate { get; set; }
    public int StatusId { get; set; }


    public Payment(int userId, int planId, int statusId)
    {
        UserId = userId;
        PlanId = planId;
        ScannerAmount = AddScannerAmount(planId);
        PlanAmount = AddPlanAmount(planId);
        ShipmentAmount = AddShipmentAmount(planId);
        SubtotalAmount = ScannerAmount + PlanAmount;
        TotalAmount = SubtotalAmount + ShipmentAmount;
        PaymentDate = new DateTime();
        StatusId = statusId;
    }

    public Payment(CreatePaymentCommand command) : this(command.UserId, command.PlanId, command.StatusId) { }

    /// <summary>
    /// Function to add the default scanner amount based on the plan Id.
    /// </summary>
    /// <param name="planId"></param>
    /// <returns></returns>
    private double AddScannerAmount(int planId)
    {
        if (planId == 1) return 35.0;
        if (planId == 2) return 0.0;
        return 0;
    }

    /// <summary>
    /// Function to add the default shipment amount based on the plan Id.
    /// </summary>
    /// <param name="planId"></param>
    /// <returns></returns>
    private double AddShipmentAmount(int planId)
    {
        if (planId == 1) return 15.0;
        if (planId == 2) return 0.0;
        return 0;
    }

    private double AddPlanAmount(int planId)
    {
        if (planId == 1) return 65.0;
        if (planId == 2) return 99.99;
        return 0;
    }
}