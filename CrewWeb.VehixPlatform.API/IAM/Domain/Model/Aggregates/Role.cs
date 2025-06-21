using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;

public partial class Role
{
    public int Id { get; }
    public string Name { get; private set; }

    public Role(string name)
    {
        Name = name;
    }

    public Role(CreateRoleCommand command) : this(command.Name)
    {
    }
}