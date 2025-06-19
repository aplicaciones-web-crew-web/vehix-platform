using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;

public interface IBadPracticeCommandService
{
    public Task<BadPractice?> Handle(CreateBadPracticesCommand command);
}