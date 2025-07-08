using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMonitoringConfiguration(this ModelBuilder builder)
    {
        //Failure Entity Configuration
        builder.Entity<Failure>().HasKey(f => f.Id);
        builder.Entity<Failure>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Failure>().Property(f => f.SuggestSolution).IsRequired().HasMaxLength(120);


        //Bad Practice Entity relation one-to-one with Failure
        builder.Entity<BadPractice>().HasKey(b => b.Id);
        builder.Entity<BadPractice>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<BadPractice>().Property(b => b.DescriptionBadPractice).IsRequired().HasMaxLength(120);

        //Odb Error Entity relation one-to-many with Failure
        builder.Entity<OdbError>().HasKey(o => o.Id);
        builder.Entity<OdbError>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<OdbError>().Property(o => o.Code).IsRequired().HasMaxLength(10);
        builder.Entity<OdbError>().Property(o => o.Title).IsRequired().HasMaxLength(50);
        builder.Entity<OdbError>().Property(o => o.Type).IsRequired().HasMaxLength(50);

        //Vehicle Failure Entity relation one-to-many with Failure
        builder.Entity<VehicleFailure>().HasKey(vf => vf.Id);
        builder.Entity<VehicleFailure>().Property(vf => vf.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<VehicleFailure>().Property(vf => vf.VehicleId).IsRequired();
        builder.Entity<VehicleFailure>().Property(vf => vf.FailureId).IsRequired();
        builder.Entity<VehicleFailure>().Property(vf => vf.Date).IsRequired().HasConversion<string>();
        builder.Entity<VehicleFailure>().Property(vf => vf.Status).IsRequired();


        // Relations Failure -> OdbError
        builder.Entity<Failure>()
            .HasOne<OdbError>()
            .WithMany()
            .HasForeignKey(failure => failure.OdbErrorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relations Failure -> BadPractice
        builder.Entity<Failure>()
            .HasOne<BadPractice>()
            .WithMany()
            .HasForeignKey(failure => failure.BadPracticeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relations VehicleFailure -> Failure
        builder.Entity<VehicleFailure>()
            .HasOne<Failure>()
            .WithMany()
            .HasForeignKey(vf => vf.FailureId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}