using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Resources;

namespace CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Transform;

public class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity)
    {
        return new PlanResource(
            entity.Id,
            entity.Name,
            entity.Price,
            entity.ImageUrl
        );
    }
}