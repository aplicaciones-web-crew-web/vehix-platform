using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class BadPracticeRepository(AppDbContext context) 
    : BaseRepository<BadPractice>(context), IBadPracticeRepository
{
    public Task<bool> ExistById(int id)
    {
        return Context.Set<BadPractice>()
            .AsNoTracking()
            .AnyAsync(p => p.Id == id);
    }
}