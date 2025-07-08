using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Transform;

public class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(
            entity.Id,
            entity.UserId,
            entity.PlanId,
            entity.PaymentDate,
            entity.StatusId,
            entity.TotalAmount
        );
    }
}