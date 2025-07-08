using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IVehicleFailureQueryService
{
    Task<VehicleFailure?> Handle(GetVehicleFailureById query);
    Task<IEnumerable<VehicleFailure>> Handle(GetAllVehiclesFailures query);
    
    Task<IEnumerable<VehicleFailure>> Handle(GetVehicleFailuresByVehicleId query);
}