using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public partial class OdbError : IErrorType
{


    public void SenToPowertrain()
    {
        Type = EErrorType.Powertrain;
    }

    public void SendToChassis()
    {
        Type = EErrorType.Chassis;

    }

    public void SendToBody()
    {
        Type = EErrorType.Body;
    }

    public void SendToNetwork()
    {
        Type = EErrorType.Network;
    }
}