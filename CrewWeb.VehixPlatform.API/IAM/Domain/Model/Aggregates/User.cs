using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;

public partial class User
{
    public int Id { get; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public int RoleId { get; private set; }
    public Role Role { get; internal set; } = null!;

    public User(string email, string passwordHash, int roleId)
    {
        Email = email;
        PasswordHash = passwordHash;
        RoleId = roleId;
    }

    public User(CreateUserCommand command) : this(command.Email, command.PasswordHash, command.RoleId)
    {
    }
}