using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Queries;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IBadPracticeQueryService
{
    Task<BadPractice?> Handle(GetBadPracticeById query);
    Task<IEnumerable<BadPractice>> Handle(GetAllBadPractices query);
}