using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class BadPracticeResourceFromEntityAssembler
{
    public static BadPracticeResource ToResourceFromEntity(BadPractice badPractice)
    {
        return new BadPracticeResource(badPractice.Id, badPractice.DescriptionBadPractice);
    }
}