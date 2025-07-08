using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class AddOdbErrorToFailureCommandFromResourceAssembler
{
    public static AddOdbErrorToFailureCommand ToCommandFromResource(AddOdbErrorToFailureResource resource,
        int failureId)
    {
        return new AddOdbErrorToFailureCommand(resource.ErrorCode, resource.ErrorCodeTitle, resource.ErrorType,failureId);
    }
}