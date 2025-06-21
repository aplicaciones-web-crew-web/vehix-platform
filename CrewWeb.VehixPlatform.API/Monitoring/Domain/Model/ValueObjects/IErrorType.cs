namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

public interface IErrorType
{
    
    void SendToPowertrain();

    void SendToChassis();
    
    void SendToBody();
    
    void SendToNetwork();
    
}