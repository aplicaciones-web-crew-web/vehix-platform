using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.SAP.Infrastructure.Persistence.EFC.Repositories;

public class PlanRepository(AppDbContext context)
    : BaseRepository<Plan>(context), IPlanRepository
{
    public Task<bool> ExistById(int id)
    {
        return Context.Set<Plan>()
            .AsNoTracking()
            .AnyAsync(p => p.Id == id);
    }

    public Task<Plan?> GetById(int id)
    {
        return Context.Set<Plan>()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}