using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Transform;

public class CreatePlanCommandFromResourceAssembler
{
    public static CreatePlanCommand ToCommandFromResource(CreatePlanResource resource)
    {
        return new CreatePlanCommand(
            resource.PlanId
        );
    }
}