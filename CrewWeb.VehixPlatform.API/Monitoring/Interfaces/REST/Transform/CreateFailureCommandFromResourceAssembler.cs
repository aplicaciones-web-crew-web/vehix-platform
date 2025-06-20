using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class CreateFailureCommandFromResourceAssembler
{
    public static CreateFailureCommand ToCommandFromResource(CreateFailureResource resource)
    {
        return new CreateFailureCommand(resource.ObdErrorId, resource.BadPracticeId, resource.SuggestSolution);
    }
}