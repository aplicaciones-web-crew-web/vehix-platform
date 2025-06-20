using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Queries;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.QueryServices;

public class BadPracticeQueryService(IBadPracticeRepository badPracticeRepository) : IBadPracticeQueryService
{
    public async Task<BadPractice?> Handle(GetBadPracticeByIdQuery query)
    {
        return await badPracticeRepository.FindByIdAsync(query.BadPracticeId);
    }

    public async Task<IEnumerable<BadPractice>> Handle(GetAllBadPracticesQuery query)
    {
        return await badPracticeRepository.ListAsync();
    }
}