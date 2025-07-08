using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.SAP.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context)
    : BaseRepository<Payment>(context), IPaymentRepository
{
    public Task<bool> ExistById(int id)
    {

        return Context.Set<Payment>()
            .AsNoTracking()
            .AnyAsync(p => p.Id == id);
    }

    public Task<Payment?> GetById(int id)
    {
        return Context.Set<Payment>()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}