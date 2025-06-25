using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.Management.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyManagementConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Vehicle>().HasKey(v => v.Id);
        builder.Entity<Vehicle>().Property(v => v.Id).IsRequired().ValueGeneratedNever();
        builder.Entity<Vehicle>().Property(v => v.FuelType).IsRequired().HasMaxLength(10);
        builder.Entity<Vehicle>().Property(v => v.Specs).IsRequired().HasMaxLength(50);
        
    }
}