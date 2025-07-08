using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class OdbErrorRepository(AppDbContext context)
    : BaseRepository<OdbError>(context), IOdbErrorRepository
{
    public Task<bool> ExistById(int id)
    {
        return Context.Set<OdbError>()
            .AsNoTracking()
            .AnyAsync(p => p.Id == id);
    }

    public Task<bool> ExistByCode(string code)
    {
        return Context.Set<OdbError>()
            .AsNoTracking()
            .AnyAsync(p => p.Code == code);
    }
}