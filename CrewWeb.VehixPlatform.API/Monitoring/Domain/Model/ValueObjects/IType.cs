namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

public interface IType
{
    void ChangeToSimple();
    void ChangeToTechnical();
    void ChangeToBadPractice();
}