using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }

    public Plan()
    {
        // This constructor is required by Entity Framework Core
        // when loading data from the database.
    }

    public Plan(string planName)
    {
        Name = AddPlanName(planName);
        Price = AddPlanPrice(planName);
        ImageUrl = AddPlanImageUrl(planName);
    }

    public Plan(CreatePlanCommand command) : this(command.Name)
    {
    }

    private string AddPlanName(string planName)
    {
        if (planName.Equals("Standard", StringComparison.OrdinalIgnoreCase))
        {
            return "Plan Standard";
        }

        if (planName.Equals("Pro", StringComparison.OrdinalIgnoreCase))
        {
            return "Plan Pro";
        }

        return string.Empty;
    }

    // Recommended adjustment for AddPlanPrice and AddPlanImageUrl
    private double AddPlanPrice(string planName) // Use planName parameter directly
    {
        // Apply the same logic as AddPlanName to ensure consistency
        if (planName.Equals("Standard", StringComparison.OrdinalIgnoreCase)) return 65.0;
        if (planName.Equals("Pro", StringComparison.OrdinalIgnoreCase)) return 99.99;
        return 0.0;
    }

    private string AddPlanImageUrl(string planName) // Use planName parameter directly
    {
        // Apply the same logic as AddPlanName to ensure consistency
        if (planName.Equals("Standard", StringComparison.OrdinalIgnoreCase))
            return
                "https://preview.redd.it/bawz2az9poaf1.png?width=268&format=png&auto=webp&s=829fb0a6da1ff9da4af4bcb58807da9d8addac59";
        if (planName.Equals("Pro", StringComparison.OrdinalIgnoreCase))
            return
                "https://preview.redd.it/fi7m6az9poaf1.png?width=268&format=png&auto=webp&s=5b56a46e051dcbfd000bc629e7327b8118ba6959";
        return string.Empty;
    }
}