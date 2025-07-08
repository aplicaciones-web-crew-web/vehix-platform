using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.ASM.Domain.Services;

public interface IVehicleCommandService
{
    public Task<Vehicle?> Handle(CreateVehicleCommand command);
    public Task<Vehicle?> Handle(UpdateVehicleCommand command);
}