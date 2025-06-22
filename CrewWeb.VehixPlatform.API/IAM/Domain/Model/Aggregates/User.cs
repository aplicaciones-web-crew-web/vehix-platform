using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;

public partial class User
{
    public int Id { get; }
    public string Name { get; private set; } = string.Empty;
    public string Lastname { get; private set; } = string.Empty;
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Dni { get; private set; } = string.Empty;
    public string Gender { get; private set; } = string.Empty;
    public int PlanId { get; private set; }
    public int RoleId { get; private set; }
    public Role Role { get; internal set; } = null!;

    public User(string name, string lastname, string email, string passwordHash, string phoneNumber, string dni, string gender, int planId, int roleId)
    {
        Name = name;
        Lastname = lastname;
        Email = email;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        Dni = dni;
        Gender = gender;
        PlanId = planId;
        RoleId = roleId;
    }

    public User(CreateUserCommand command) : this(command.Name, command.Lastname, command.Email, command.PasswordHash, command.PhoneNumber, command.Dni, command.Gender, command.PlanId, command.RoleId)
    {
    }
}