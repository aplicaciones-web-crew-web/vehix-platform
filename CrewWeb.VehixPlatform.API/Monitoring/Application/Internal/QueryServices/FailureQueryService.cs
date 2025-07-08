using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.QueryServices;

public class FailureQueryService(IFailureRepository failureRepository) : IFailureQueryService
{
    public async Task<Failure?> Handle(GetFailureById query)
    {
        return await failureRepository.FindByIdAsync(query.FailureId);
    }

    public async Task<IEnumerable<Failure>> Handle(GetAllFailures query)
    {
        return await failureRepository.ListAsync();
    }

    public async Task<IEnumerable<Failure>> Handle(GetAllFailuresByErrorType query)
    {
        return await failureRepository.FindByErrorType(query.ErrorType);
    }
}