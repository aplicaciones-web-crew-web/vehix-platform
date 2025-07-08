namespace CrewWeb.VehixPlatform.API.Monitoring.Interfaces.REST.Resources;

public record OdbErrorResource(
    int Id, 
    string Code, 
    string Title, 
    string Type);