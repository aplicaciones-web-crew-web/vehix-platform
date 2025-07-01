using CrewWeb.VehixPlatform.API.Management.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Services;

public interface IVehicleQueryService
{
    Task<Vehicle?> Handle(GetVehicleByIdQuery query);
    
    Task<Enumerable<Vehicle>> Handle(GetAllVehiclesQuery query);
}