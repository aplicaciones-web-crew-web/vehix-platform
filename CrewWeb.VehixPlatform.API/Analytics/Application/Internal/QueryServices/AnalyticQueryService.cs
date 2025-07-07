using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Services;

namespace CrewWeb.VehixPlatform.API.Analytics.Application.Internal.QueryServices;

public class AnalyticQueryService(IAnalyticRepository analyticRepository) : IAnalyticQueryService
{
    public async Task<Analytic?> Handle(GetAnalyticByIdQuery query)
    {
        return await analyticRepository.FindByIdAsync(query.AnalyticId);
    }

    public async Task<IEnumerable<Analytic>> Handle(GetAllAnalyticsQuery query)
    {
        return await analyticRepository.ListAsync();
    }

    public async Task<Analytic?> Handle(GetAnalyticByVehicleId query)
    {
        return await analyticRepository.GetByVehicleId(query.VehicleId);
    }
}