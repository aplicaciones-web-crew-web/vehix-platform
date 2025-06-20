using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public partial class OdbError(string errorCode, string errorCodeTitle, string errorType)
{
    public int Id { get; set; }
    public string ErrorCode { get; private set; } = errorCode;
    public string ErrorCodeTitle { get; private set; } = errorCodeTitle;

    public string ErrorType { get; private set; } = errorType;

    public EErrorType Type { get; set; } = ParseErrorType(errorType);


    public OdbError() : this(string.Empty, string.Empty, string.Empty)
    {
    }

    public OdbError(CreateOdbErrorCommand command) : this(command.ErrorCode, command.ErrorCodeTitle, command.ErrorType)
    {
    }

    /// <summary>
    /// Parses the error type from a string representation.
    /// </summary>
    /// <param name="errorTypeString"></param>
    /// <returns></returns>
    private static EErrorType ParseErrorType(string errorTypeString)
    {
        return Enum.TryParse<EErrorType>(errorTypeString, true, out var result)
            ? result
            : EErrorType.Undefined;
    }
}