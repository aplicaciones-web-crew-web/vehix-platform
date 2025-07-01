using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Services;

public interface IVehicleCommandService
{
    Task<Vehicle?> Handle(CreateVehicleCommand command);
    Task<Vehicle?> Handle(DeleteVehicleCommand command);
    Task<Vehicle?> Handle(SetDefaultVehicleCommand command);
    Task<Vehicle> CreateVehicleAsync(CreateVehicleCommand createVehicleCommand);
}