using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class AddBadPracticeToFailureCommandFromResourceAssembler
{
    public static AddBadPracticeToFailureCommand ToCommandFromResource(AddBadPracticeToFailureResource resource, int failureId)
    {
        return new AddBadPracticeToFailureCommand(resource.DescriptionBadPractice, failureId);
    }
}