using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;

public partial class User
{
    public int Id { get; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Dni { get; private set; } = string.Empty;
    public string Gender { get; private set; } = string.Empty;
    public int PlanId { get; private set; }

    public User(string name, string lastName, string email, string password, string phoneNumber, string dni, string gender, int planId)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Dni = dni;
        Gender = gender;
        PlanId = planId;
    }

    public User(CreateUserCommand command) : this(command.Name, command.LastName, command.Email, command.Password, command.PhoneNumber, command.Dni, command.Gender, command.PlanId)
    {
    }
}