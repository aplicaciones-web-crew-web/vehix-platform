using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class FailureResourceFromEntityAssembler
{
    public  static FailureResource ToResourceFromEntity(Failure entity)
    {
        return new FailureResource(
            entity.Id,
            entity.SuggestSolution,
            BadPracticeResourceFromEntityAssembler.ToResourceFromEntity(entity.BadPractice),
            OdbErrorResourceFromEntityAssembler.ToResourceFromEntity(entity.OdbError),
            entity.Status.GetDisplayName(),
            entity.Type.GetDisplayName(),
            entity.Urgency.GetDisplayName()
        );
    }
    
}