using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Services;

public interface IAnalyticCommandService
{
    public Task<Analytic?> Handle(CreateAnalyticCommand command);
    public Task<Analytic?> Handle(UpdateAnalyticCommand command);
    public Task<Analytic?> Handle(UpdateAnalyticByVehicleIdCommand command);
}