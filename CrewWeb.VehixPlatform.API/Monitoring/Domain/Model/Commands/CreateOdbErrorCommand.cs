namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

public record CreateOdbErrorCommand(
    string Code,
    string Title,
    string Type
);