using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;

namespace CrewWeb.VehixPlatform.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}