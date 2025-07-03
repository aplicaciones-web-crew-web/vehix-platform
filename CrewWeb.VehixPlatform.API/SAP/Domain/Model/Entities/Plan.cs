using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Entities;

public class Plan
{
    public int Id { get; set; }

    public EPlan PlanType { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }

    public Plan(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public Plan(CreatePlanCommand command) : this(
        command.Name,
        command.Price
    )
    {
    }
}