using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Services;

/// <summary>
/// Interface for querying payment information.
/// </summary>
public interface IPaymentQueryService
{
    /// <summary>
    /// Retrieves a probable payment by its unique identifier.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Payment?> Handle(GetPaymentByIdQuery query);
    

    /// <summary>
    /// Retrieves all payments.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
}