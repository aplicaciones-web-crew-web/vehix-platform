using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Services;

public interface IAnalyticQueryService
{
    Task<Analytic?> Handle(GetAnalyticByIdQuery query);

    Task<IEnumerable<Analytic>> Handle(GetAllAnalyticsQuery query);
}