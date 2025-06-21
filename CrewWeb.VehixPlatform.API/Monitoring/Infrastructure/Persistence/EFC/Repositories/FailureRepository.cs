using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class FailureRepository(AppDbContext context) : BaseRepository<Failure>(context), IFailureRepository
{
    public async Task<IEnumerable<Failure>> FindByErrorType(string errorType)
    {
        return await Context.Set<Failure>()
            .Include(failure => failure.OdbError)
            .Include(failure => failure.BadPractice)
            .Where(failure => failure.OdbError.ErrorTypeString == errorType)
            .ToListAsync();
    }

    public async Task<IEnumerable<Failure>> FindBySuggestSolution(string suggestSolution)
    {
        return await Context.Set<Failure>()
            .Include(failure => failure.OdbError)
            .Include(failure => failure.BadPractice)
            .Where(failure => failure.SuggestSolution == suggestSolution)
            .ToListAsync();
    }

    public async Task<IEnumerable<Failure>> FindByStatus(string status)
    {
        return await Context.Set<Failure>()
            .Include(failure => failure.OdbError)
            .Include(failure => failure.BadPractice)
            .Where(failure => failure.Status.ToString() == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<Failure>> FindByType(string type)
    {
        return await Context.Set<Failure>()
            .Include(failure => failure.OdbError)
            .Include(failure => failure.BadPractice)
            .Where(failure => failure.Type.ToString() == type)
            .ToListAsync();
    }


    
    
    
    
    public new async Task<Failure?> FindByIdAsync(int id)
    {
        // Include everything that you need to show
        return await Context.Set<Failure>()
            .Include(failure => failure.OdbError)
            .Include(failure => failure.BadPractice)
            .FirstOrDefaultAsync(failure => failure.Id == id);
    }

    public new async Task<IEnumerable<Failure>> ListAsync()
    {
        return await Context.Set<Failure>()
            .Include(failure => failure.OdbError)
            .Include(failure => failure.BadPractice)
            .ToListAsync();
    }
}