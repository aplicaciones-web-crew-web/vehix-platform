using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
public partial class OdbError
{
    public int Id { get; set; }
    public string ErrorCode { get; private set; }
    public string ErrorCodeTitle { get; private set; }
    
    public string ErrorType { get; private set; }

    public OdbError(string errorCode, string errorCodeTitle, string errorType)
    {
        ErrorCode = errorCode;
        ErrorCodeTitle = errorCodeTitle;
        ErrorType = errorType;
    }

    public OdbError(CreateOdbErrorCommand command) : this(command.ErrorCode, command.ErrorCodeTitle, command.ErrorType)
    {
    }
}
