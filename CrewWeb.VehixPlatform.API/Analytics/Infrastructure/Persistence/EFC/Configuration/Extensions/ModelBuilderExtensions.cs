using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Analytics.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAnalyticsConfiguration(this ModelBuilder builder)
    {
        // Analytics Table Configuration
        builder.Entity<Analytic>().HasKey(analytic => analytic.Id);
        builder.Entity<Analytic>().Property(analytic => analytic.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Analytic>().Property(analytic => analytic.VehicleId).IsRequired();
        builder.Entity<Analytic>().Property(analytic => analytic.Engine).IsRequired();
        builder.Entity<Analytic>().Property(analytic => analytic.Transmission).IsRequired();
        builder.Entity<Analytic>().Property(analytic => analytic.Brake).IsRequired();
        builder.Entity<Analytic>().Property(analytic => analytic.Electrical).IsRequired();
        builder.Entity<Analytic>().Property(analytic => analytic.Steering).IsRequired();
        builder.Entity<Analytic>().Property(analytic => analytic.Suspension).IsRequired();
        builder.Entity<Analytic>().Property(analytic => analytic.Fuel).IsRequired();
        builder.Entity<Analytic>().Property(analytic => analytic.Refrigeration).IsRequired();

        // RelationShips Analytics -> Vehicles
        /*
        builder.Entity<Analytic>()
            .HasOne<Vehicle>()
            .WithMany()
            .HasForeignKey(analytic => analytic.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
            */
    }
}