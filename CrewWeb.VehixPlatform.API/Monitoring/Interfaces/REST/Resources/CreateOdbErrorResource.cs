namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record CreateOdbErrorResource(
    string Code, 
    string Title,
    string Type);