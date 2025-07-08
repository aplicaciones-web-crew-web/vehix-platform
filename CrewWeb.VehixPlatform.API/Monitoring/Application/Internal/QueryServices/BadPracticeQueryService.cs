using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.QueryServices;

public class BadPracticeQueryService(IBadPracticeRepository badPracticeRepository) : IBadPracticeQueryService
{
    public async Task<BadPractice?> Handle(GetBadPracticeById query)
    {
        return await badPracticeRepository.FindByIdAsync(query.BadPracticeId);
    }

    public async Task<IEnumerable<BadPractice>> Handle(GetAllBadPractices query)
    {
        return await badPracticeRepository.ListAsync();
    }
}