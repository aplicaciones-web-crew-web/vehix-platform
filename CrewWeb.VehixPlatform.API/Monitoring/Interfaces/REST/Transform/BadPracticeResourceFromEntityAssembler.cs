using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class BadPracticeResourceFromEntityAssembler
{
    public static BadPracticeResource ToResourceFromEntity(BadPractice entity)
    {
        return new BadPracticeResource(
            entity.Id,
            entity.DescriptionBadPractice
        );
    }
}