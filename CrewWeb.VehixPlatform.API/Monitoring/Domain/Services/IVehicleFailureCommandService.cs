using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IVehicleFailureCommandService
{
    public Task<VehicleFailure?> Handle(CreateVehicleFailureCommand command);
    
    public Task<VehicleFailure?> Handle(UpdateVehicleFailureCommand command);

}