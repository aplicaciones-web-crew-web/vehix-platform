using CrewWeb.VehixPlatform.API.Analytics.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrewWeb.VehixPlatform.API.ASM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrewWeb.VehixPlatform.API.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CrewWeb.VehixPlatform.API.SAP.Infrastructure.Persistence.EFC.Configuration.Extensions;
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
        
        // Apply configurations for the Identity and Access Management bounded context
        builder.ApplyIamConfiguration();
        
        // Apply Configurations for the Subscription bounded context
        builder.ApplySubscriptionsConfiguration();
        
        // Apply configurations for the Analytics bounded context
        builder.ApplyAnalyticsConfiguration();
        
        // Apply configurations for the ASM bounded context
        builder.ApplyAssetsAndResourceManagementConfiguration();
        
        
        // Use snake case naming convention for the database
        builder.UseSnakeCaseNamingConvention();
    }
}