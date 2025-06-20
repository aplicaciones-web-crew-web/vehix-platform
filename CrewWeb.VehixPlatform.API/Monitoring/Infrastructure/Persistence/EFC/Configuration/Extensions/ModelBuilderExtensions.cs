using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMonitoringConfiguration(this ModelBuilder builder)
    {
        //Monitoring Context ORM Mapping Rules
        
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
        builder.Entity<OdbError>().Property(o => o.ErrorCode).IsRequired().HasMaxLength(5);
        builder.Entity<OdbError>().Property(o => o.ErrorCodeTitle).IsRequired().HasMaxLength(50);
        builder.Entity<OdbError>().Property(o => o.ErrorType).IsRequired().HasMaxLength(20);

        
        //Relations: failure->OdbError
        builder.Entity<Failure>()
            .HasOne(f => f.OdbError) //Failure has one Odb Error
            .WithMany() // Odb Error can be in many failures
            .HasForeignKey("odb_error_id");
        
        //Relations: failure->BadPractice
        builder.Entity<Failure>()
            .HasOne(f=> f.BadPractice)//Failure has one Bad Practice
            .WithMany() // Bad Practice can be in many failures
            .HasForeignKey("bad_practice_id");

    }
}
