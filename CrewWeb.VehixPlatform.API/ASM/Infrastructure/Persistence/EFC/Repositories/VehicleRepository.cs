using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.ASM.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.ASM.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context)
    : BaseRepository<Vehicle>(context), IVehicleRepository
{
    public Task<bool> ExistById(int id)
    {
        return Context.Set<Vehicle>()
            .AsNoTracking()
            .AnyAsync(p => p.Id == id);
    }

    public Task<Vehicle?> GetById(int id)
    {
        return Context.Set<Vehicle>()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Vehicle>> FindByUserId(int userId)
    {
        return await Context.Set<Vehicle>()
            .AsNoTracking()
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }
}