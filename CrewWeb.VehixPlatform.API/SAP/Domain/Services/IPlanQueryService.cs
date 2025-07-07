using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Services;

/// <summary>
/// Interface for querying plans in the system.
/// </summary>
public interface IPlanQueryService
{
    /// <summary>
    /// Retrieves a probable plan by its ID.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Plan?> Handle(GetPlanByIdQuery query);
    
    


    /// <summary>
    /// Retrieves all plans available in the system.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query);

    /// <summary>
    /// Retrieves a plan by its name.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<Plan?> Handle(GetPlanByNameQuery query);
}