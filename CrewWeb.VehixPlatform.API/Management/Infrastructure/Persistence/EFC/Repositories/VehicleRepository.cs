using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Management.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Management.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context): BaseRepository<Vehicle>(context), IVehicleRepository
{
    public async Task<IEnumerable<Vehicle>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Vehicle>()
            .Where(vehicle => vehicle.OwnerId.Id == userId)
            .ToListAsync();
    }

    public async Task<bool> ExistsByPlateAsync(string plate)
    {
        return await Context.Set<Vehicle>().AnyAsync(vehicle => vehicle.Plate.Value == plate);
    }

    public new async Task<Vehicle?> FindByIdAsync(string plate)
    {
        return await Context.Set<Vehicle>()
            .FirstOrDefaultAsync(vehicle => vehicle.Plate.Value == plate);
    }

    public new async Task<IEnumerable<Vehicle>> ListAsync()
    {
        return await Context.Set<Vehicle>()
            .ToListAsync();
    }
}