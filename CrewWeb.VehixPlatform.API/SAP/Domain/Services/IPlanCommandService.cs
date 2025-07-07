using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Services;

/// <summary>
/// This service is responsible for handling commands related to Plan entities.
/// </summary>
public interface IPlanCommandService
{
    /// <summary>
    /// Prepare the service to receive probably null input.
    /// To don't have failures in the system, we will return null if the input Plan failed.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public Task<Plan?> Handle(CreatePlanCommand command);
}