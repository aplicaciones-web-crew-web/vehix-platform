using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class CreateOdbErrorCommandFromResourceAssembler
{
    public static CreateOdbErrorCommand ToCommandFromResource(CreateOdbErrorResource resource)
    {
        return new CreateOdbErrorCommand(resource.ErrorCode, resource.ErrorCodeTitle);
    }
}