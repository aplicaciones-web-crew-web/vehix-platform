using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public class OdbError
{
    public int Id { get; set; }
    public string ErrorCode { get; set; }
    public string ErrorTitle { get; set; }

    public string ErrorType { get;  set; }
    

    public OdbError(string errorCode, string errorCodeTitle, string errorType)
    {
        ErrorCode = errorCode;
        ErrorTitle = errorCodeTitle;
        ErrorType = errorType;
    }

    public OdbError(CreateOdbErrorCommand command) : this(command.ErrorCode, command.ErrorCodeTitle, command.ErrorType)
    {
    }
}