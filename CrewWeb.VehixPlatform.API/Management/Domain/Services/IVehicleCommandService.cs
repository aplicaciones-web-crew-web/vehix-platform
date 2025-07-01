using CrewWeb.VehixPlatform.API.Management.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Services;

public interface IVehicleCommandService
{
    public Task<Vehicle> Handle(CreateVehicleCommand command);
}