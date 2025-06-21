using CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Apply configurations for the Monitoring bounded context

        builder.ApplyMonitoringConfiguration();

        // Use snake case naming convention for the database
        builder.UseSnakeCaseNamingConvention();
    }
}