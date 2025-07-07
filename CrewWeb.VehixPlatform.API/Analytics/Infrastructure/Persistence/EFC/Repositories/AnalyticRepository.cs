using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Analytics.Infrastructure.Persistence.EFC.Repositories;

public class AnalyticRepository(AppDbContext context)
    : BaseRepository<Analytic>(context), IAnalyticRepository
{
    public Task<bool> ExistByVehicleId(int vehicleId)
    {
        return Context.Set<Analytic>()
                .AsNoTracking()
                .AnyAsync(a=> a.VehicleId == vehicleId)
            ;
    }

    public Task<Analytic?> GetByVehicleId(int vehicleId)
    {
        return Context.Set<Analytic>()
                .AsNoTracking()
                .FirstOrDefaultAsync(a=> a.VehicleId == vehicleId)
            ;
    }
}