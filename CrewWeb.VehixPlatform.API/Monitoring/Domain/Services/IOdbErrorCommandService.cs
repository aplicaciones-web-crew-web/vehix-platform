using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IOdbErrorCommandService
{
    public Task<OdbError?> Handle(CreateOdbErrorCommand command);

}