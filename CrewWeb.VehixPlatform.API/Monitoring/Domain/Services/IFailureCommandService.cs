using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IFailureCommandService
{
    public Task<Failure?> Handle(CreateFailureCommand command);
    
    Task<Failure?> Handle(AddBadPracticeToFailureCommand command);
    Task<Failure?> Handle(AddOdbErrorToFailureCommand command);


}