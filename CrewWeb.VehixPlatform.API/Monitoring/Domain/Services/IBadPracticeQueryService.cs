using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Queries;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IBadPracticeQueryService
{
    Task<BadPractice?> Handle(GetBadPracticeByIdQuery query);
    Task<IEnumerable<BadPractice>> Handle(GetAllBadPracticesQuery query);
}