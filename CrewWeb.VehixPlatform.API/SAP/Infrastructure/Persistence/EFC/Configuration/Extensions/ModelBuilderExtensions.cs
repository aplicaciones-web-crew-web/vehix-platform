using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewWeb.VehixPlatform.API.SAP.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySubscriptionsConfiguration(this ModelBuilder builder)
    {
        // Payments Table Configuration
        builder.Entity<Payment>().HasKey(payment => payment.Id);
        builder.Entity<Payment>().Property(payment => payment.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(payment => payment.UserId).IsRequired();
        builder.Entity<Payment>().Property(payment => payment.PlanId).IsRequired();
        builder.Entity<Payment>().Property(payment => payment.TotalAmount).IsRequired();
        builder.Entity<Payment>().Property(payment => payment.PaymentDate).IsRequired();
        builder.Entity<Payment>().Property(payment => payment.StatusId).IsRequired();


        // RelationShips Payments -> Plans
        builder.Entity<Payment>()
            .HasOne<Plan>()
            .WithMany()
            .HasForeignKey(payment => payment.PlanId)
            .OnDelete(DeleteBehavior.Restrict);


        // Plan properties
        builder.Entity<Plan>().HasKey(plan => plan.Id);
        builder.Entity<Plan>().Property(plan => plan.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(plan => plan.PlanName).IsRequired().HasMaxLength(100);
        builder.Entity<Plan>().Property(plan => plan.ImageUrl).IsRequired().HasMaxLength(250);
        builder.Entity<Plan>().Property(plan => plan.Price).IsRequired();
    }
}