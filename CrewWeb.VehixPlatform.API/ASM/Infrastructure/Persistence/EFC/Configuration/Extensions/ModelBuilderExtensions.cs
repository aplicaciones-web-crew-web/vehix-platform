using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.ASM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAssetsAndResourceManagementConfiguration(this ModelBuilder builder)
    {
        // Vehicles Table Configuration
        builder.Entity<Vehicle>().HasKey(vehicle => vehicle.Id);
        builder.Entity<Vehicle>().Property(vehicle => vehicle.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vehicle>().Property(vehicle => vehicle.UserId).IsRequired();
        builder.Entity<Vehicle>().Property(vehicle => vehicle.Description).IsRequired().HasMaxLength(500);
        builder.Entity<Vehicle>().Property(vehicle => vehicle.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Vehicle>().Property(vehicle => vehicle.Brand).IsRequired().HasMaxLength(50);
        builder.Entity<Vehicle>().Property(vehicle => vehicle.Model).IsRequired().HasMaxLength(50);
        builder.Entity<Vehicle>().Property(vehicle => vehicle.Mileage).IsRequired();
        builder.Entity<Vehicle>().Property(vehicle => vehicle.Year).IsRequired();
        builder.Entity<Vehicle>().Property(vehicle => vehicle.ImageUrl).IsRequired().HasMaxLength(500);

        // Relationships Vehicles -> Users
        /*
        builder.Entity<Vehicle>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(vehicle => vehicle.UserId)
            .OnDelete(DeleteBehavior.Restrict);*/
    }
}