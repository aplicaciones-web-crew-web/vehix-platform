namespace CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Resources;

public record PlanResource(
    int Id,
    string Name,
    double Price,
    string ImageUrl
);