using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class FailureRepository(AppDbContext context) :
    BaseRepository<Failure>(context), IFailureRepository
{
    public Task<bool> ExistById(int id)
    {
        return Context.Set<Failure>()
            .AsNoTracking()
            .AnyAsync(p => p.Id == id);
    }

    public Task<Failure?> FindByOdbErrorId(int odbErrorId)
    {
        return Context.Set<Failure>()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.OdbErrorId == odbErrorId);
    }
}