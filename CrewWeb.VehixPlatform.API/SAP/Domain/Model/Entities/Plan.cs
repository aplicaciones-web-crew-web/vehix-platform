using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;

public class Plan
{
    public int Id { get; set; }

    public int PlanId { get; set; }

    public string PlanName { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }

    public Plan(int planId)
    {
        PlanId = planId;
        PlanName = AddPlanName(planId);
        Price = AddPlanPrice(planId);
        ImageUrl = AddPlanImageUrl(planId);
    }

    public Plan(CreatePlanCommand command) : this(command.PlanId)
    {
    }

    private string AddPlanName(int planId)
    {
        if (planId == 1) return "Standard";
        if (planId == 2) return "Pro";
        return "";
    }

    private double AddPlanPrice(int planId)
    {
        if (planId == 1) return 65.0;
        if (planId == 2) return 99.99;
        return 0.0;
    }

    private string AddPlanImageUrl(int planId)
    {
        if (planId == 1)
            return
                "https://preview.redd.it/bawz2az9poaf1.png?width=268&format=png&auto=webp&s=829fb0a6da1ff9da4af4bcb58807da9d8addac59";
        if (planId == 2)
            return
                "https://preview.redd.it/fi7m6az9poaf1.png?width=268&format=png&auto=webp&s=5b56a46e051dcbfd000bc629e7327b8118ba6959";
        return string.Empty;
    }
}