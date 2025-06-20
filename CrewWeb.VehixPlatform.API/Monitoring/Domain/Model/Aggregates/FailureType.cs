using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;

public partial class Failure : IType
{
    public EFailureType Type { get; protected set; }

    public void ChangeToSimple()
    {
        Type = EFailureType.Simple;
    }

    public void ChangeToTechnical()
    {
        Type = EFailureType.Technical;
    }

    public void ChangeToBadPractice()
    {
        Type = EFailureType.BadPractice;
    }
}