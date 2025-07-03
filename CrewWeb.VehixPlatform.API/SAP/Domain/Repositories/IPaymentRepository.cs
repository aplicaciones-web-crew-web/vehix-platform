using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<bool> ExistByUserId(int userId);
}