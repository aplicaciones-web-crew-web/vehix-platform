using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class CreateBadPracticeCommandFromResourceAssembler
{
    public static CreateBadPracticeCommand ToCommandFromResource(CreateBadPracticeResource resource)
    {
        return new CreateBadPracticeCommand(resource.DescriptionBadPractice);
    }
}