using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Role>().HasKey(r => r.Id);
        builder.Entity<Role>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(50);

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(u => u.Password).IsRequired();
        builder.Entity<User>().Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.Entity<User>().Property(u => u.Dni).IsRequired().HasMaxLength(20);
        builder.Entity<User>().Property(u => u.Gender).IsRequired().HasMaxLength(10);
        builder.Entity<User>().Property(u => u.PlanId).IsRequired();

        // Users are stored without relation to roles
    }
}