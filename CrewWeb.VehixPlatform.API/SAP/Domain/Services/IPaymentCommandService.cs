using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Services;

/// <summary>
/// Interface for the payment command service.
/// </summary>
public interface IPaymentCommandService
{
    /// <summary>
    /// Prepare the service to receive probably null input.
    /// To don't have failures in the system, we will return null if the iNput payment failed.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public Task<Payment?> Handle(CreatePaymentCommand command);
}