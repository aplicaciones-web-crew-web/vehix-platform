using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public partial class OdbError
{
    public int Id { get; set; }
    public string ErrorCode { get; private set; }
    public string ErrorCodeTitle { get; private set; }

    public EErrorType ErrorType { get; private set; }
    


    public OdbError(string errorCode, string errorCodeTitle)
    {
        ErrorCode = errorCode;
        ErrorCodeTitle = errorCodeTitle;
    }
    public OdbError(CreateOdbErrorCommand command) : this(command.ErrorCode, command.ErrorCodeTitle)
    {
    }
    
}