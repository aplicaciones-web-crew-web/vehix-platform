using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
public class OdbError
{
    public int Id { get; set; }
    public string ErrorCode { get; private set; }
    public string ErrorCodeTitle { get; private set; }
    
    public EErrorType Type { get; private set; }
    
    public string ErrorTypeString
    {
        get => Type.ToString();
        set => Type = Enum.TryParse<EErrorType>(value, true, out var result) ? result : EErrorType.Undefined;
    }
    protected OdbError() { } 
    public OdbError(string errorCode, string errorCodeTitle, string errorType)
    {
        ErrorCode = errorCode;
        ErrorCodeTitle = errorCodeTitle;
        ErrorTypeString = errorType;
    }

    public OdbError(CreateOdbErrorCommand command) : this(command.ErrorCode, command.ErrorCodeTitle, command.ErrorType)
    {
    }
}
