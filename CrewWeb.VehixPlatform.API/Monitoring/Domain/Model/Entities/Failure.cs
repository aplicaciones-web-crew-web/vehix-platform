using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public class Failure
{
    public int Id { get; }

    public string Title { get; set; }

    public string SuggestSolution { get; set; }

    public int BadPracticeId { get; set; }
    public int OdbErrorId { get; set; }

    public string Urgency { get; set; }


    public Failure(string title, string suggestSolution, int badPracticeId, int odbErrorId, string urgency)
    {
        Title = title;
        SuggestSolution = suggestSolution;
        BadPracticeId = badPracticeId;
        OdbErrorId = odbErrorId;
        Urgency = AddUrgency(urgency);
    }

    public Failure(CreateFailureCommand command) : this(command.Title, command.SuggestSolution, command.BadPracticeId,
        command.OdbErrorId, command.Urgency)
    {
    }

    private string AddUrgency(string urgency)
    {
        if (urgency.Equals("Critical", StringComparison.OrdinalIgnoreCase))
        {
            return "Critical";
        }

        if (urgency.Equals("Moderate", StringComparison.OrdinalIgnoreCase))
        {
            return "Moderate";
        }

        if (urgency.Equals("Mild", StringComparison.OrdinalIgnoreCase))
        {
            return "Mild";
        }

        return string.Empty;
    }
}