namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

public interface IUrgency
{
    void ChangeToCritical();
    void ChangeToModerate();
    void ChangeToMild();
}