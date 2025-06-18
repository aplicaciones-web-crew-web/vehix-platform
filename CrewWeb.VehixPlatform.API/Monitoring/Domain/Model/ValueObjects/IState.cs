namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

public interface IState
{
    void ChangeToFixed();
    void ChangeToPending();
}