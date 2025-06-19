using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public class OdbError(string errorCode, string errorCodeTitle, string errorCodeType)
{
    public int Id { get; set; }
    public string ErrorCode { get; set; } = errorCode;
    public string ErrorCodeTitle { get; set; } = errorCodeTitle;
    public string ErrorCodeType { get; set; } = errorCodeType;

    public OdbError() : this(string.Empty, string.Empty, string.Empty)
    {
    }

    public OdbError(CreateOdbErrorCommand command) : this(command.ErrorCode, command.ErrorCodeTitle,
        command.ErrorCodeType)
    {
    }
}