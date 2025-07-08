using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.ASM.Domain.Services;

public interface IVehicleQueryService
{
    Task<Vehicle?> Handle(GetVehicleByIdQuery query);
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query);
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesByUserId query);
}