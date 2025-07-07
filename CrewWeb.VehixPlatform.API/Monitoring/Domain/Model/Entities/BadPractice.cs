using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public class BadPractice
{
    public int Id { get; set; }
    public string DescriptionBadPractice { get; set; }


    public BadPractice(string descriptionBadPractice)
    {
        DescriptionBadPractice = descriptionBadPractice;
    }

    public BadPractice(CreateBadPracticeCommand command) : this(command.DescriptionBadPractice)
    {
    }
}