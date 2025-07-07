using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Transform;

public class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(
            resource.UserId,
            resource.PlanId,
            resource.StatusId
        );
    }
}