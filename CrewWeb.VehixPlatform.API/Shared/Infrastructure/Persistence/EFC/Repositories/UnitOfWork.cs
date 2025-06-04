using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context): IUnitOfWork
{
    /// <inheritdoc />
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}