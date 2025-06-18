using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public class OdbError(string errorCode, string errorTitle)
{
    public int Id { get; set; }
    public string ErrorCode { get; set; } = errorCode;
    public string ErrorTitle { get; set; } = errorTitle;
    
    public OdbError() : this(string.Empty, string.Empty){}

    public OdbError(CreateOdbErrorCommand command) : this(command.ErrorCode, command.ErrorTitle)
    {
        
    }
}