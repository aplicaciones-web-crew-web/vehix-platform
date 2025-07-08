using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;
using CrewWeb.VehixPlatform.API.SAP.Domain.Services;

namespace CrewWeb.VehixPlatform.API.SAP.Application.Internal.QueryServices;

public class PlanQueryService(IPlanRepository planRepository):IPlanQueryService
{
    public async Task<Plan?> Handle(GetPlanByIdQuery query)
    {
        return await planRepository.FindByIdAsync(query.PlanId);
    }

    public async Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query)
    {
        return await planRepository.ListAsync();
    }

    public async Task<Plan?> Handle(GetPlanByNameQuery query)
    {
        return await planRepository.FindByName(query.PlanName);
    }
}