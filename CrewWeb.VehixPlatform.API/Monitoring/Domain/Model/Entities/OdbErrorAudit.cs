using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public partial class OdbError : IErrorType
{
    public void SenToPowertrain()
    {
        ErrorType = EErrorType.Powertrain;
    }

    public void SendToChassis()
    {
        ErrorType = EErrorType.Chassis;

    }

    public void SendToBody()
    {
        ErrorType = EErrorType.Body;
    }

    public void SendToNetwork()
    {
        ErrorType = EErrorType.Network;
    }
}