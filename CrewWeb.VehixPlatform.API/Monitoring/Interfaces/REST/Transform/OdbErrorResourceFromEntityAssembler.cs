using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Transform;

public static class OdbErrorResourceFromEntityAssembler
{
    public static OdbErrorResource ToResourceFromEntity(OdbError odbError)
    {
        return new OdbErrorResource(
            odbError.Id, 
            odbError.Code, 
            odbError.Title, 
            odbError.Type);
    }
}