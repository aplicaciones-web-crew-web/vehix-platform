using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public class OdbError
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }

    public string Type { get; set; }


    public OdbError(string code, string title, string type)
    {
        Code = code;
        Title = title;
        Type = AddType(type);
    }

    public OdbError(CreateOdbErrorCommand command) : this(command.Code, command.Title, command.Type)
    {
    }

    private string AddType(string type)
    {
        if (type.Equals("Chassis", StringComparison.OrdinalIgnoreCase))
        {
            return "Chassis";
        }

        if (type.Equals("Body", StringComparison.OrdinalIgnoreCase))
        {
            return "Body";
        }

        if (type.Equals("Network", StringComparison.OrdinalIgnoreCase))
        {
            return "Network";
        }

        return string.Empty;
    }
}