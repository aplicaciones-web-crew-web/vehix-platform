using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class BadPracticeRepository(AppDbContext context) : BaseRepository<BadPractice>(context), IBadPracticeRepository;