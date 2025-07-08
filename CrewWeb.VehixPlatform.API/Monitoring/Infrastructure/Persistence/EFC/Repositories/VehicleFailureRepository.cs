using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class VehicleFailureRepository(AppDbContext context)
    : BaseRepository<VehicleFailure>(context), IVehicleFailureRepository
{
    public async Task<IEnumerable<VehicleFailure>> FindByVehicleId(int vehicleId)
    {
        return await Context.Set<VehicleFailure>()
            .AsNoTracking()
            .Where(p => p.VehicleId == vehicleId)
            .ToListAsync();
    }

    public Task<bool> ExistByVehicleId(int vehicleId)
    {
        return Context.Set<VehicleFailure>()
            .AsNoTracking()
            .AnyAsync(p => p.VehicleId == vehicleId);
    }

    public Task<bool> ExistById(int vehicleFailureId)
    {
        return Context.Set<VehicleFailure>()
            .AsNoTracking()
            .AnyAsync(p => p.Id == vehicleFailureId);
    }
}