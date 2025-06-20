namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

public interface IErrorType
{
    
    void SenToPowertrain();

    void SendToChassis();
    
    void SendToBody();
    
    void SendToNetwork();
    
}