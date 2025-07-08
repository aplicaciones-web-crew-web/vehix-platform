using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IFailureCommandService
{
    public Task<Failure?> Handle(CreateFailureCommand command);
}