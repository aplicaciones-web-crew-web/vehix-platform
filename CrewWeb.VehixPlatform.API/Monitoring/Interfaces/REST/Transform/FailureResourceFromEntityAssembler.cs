using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class FailureResourceFromEntityAssembler
{
    public static FailureResource ToResourceFromEntity(Failure entity)
    {
        return new FailureResource(
            entity.Id,
            entity.Title,
            entity.SuggestSolution,
            entity.BadPracticeId,
            entity.OdbErrorId,
            entity.Urgency
        );
    }
}