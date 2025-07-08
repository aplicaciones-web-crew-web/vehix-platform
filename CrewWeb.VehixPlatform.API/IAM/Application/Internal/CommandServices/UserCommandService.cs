using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.IAM.Domain.Repositories;
using CrewWeb.VehixPlatform.API.IAM.Domain.Services;
using CrewWeb.VehixPlatform.API.IAM.Application.Internal.OutboundServices;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,

    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(
            command.Name,
            command.LastName,
            command.Email,
            hashedPassword,
            command.PhoneNumber,
            command.Dni,
            command.Gender,
            command.PlanId);
        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();

        return user;
    }
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByDniAsync(command.Dni);
        if (user == null || !hashingService.VerifyPassword(command.Password, user.Password))
            throw new Exception("Invalid credentials");

        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
}