using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;

public class LibraryItem
{
    public int Id { get; }
    public ELibraryType Type { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    protected LibraryItem()
    {
    }

    public LibraryItem(ELibraryType type, string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty.", nameof(title));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description cannot be empty.", nameof(description));

        Type = type; //
        Title = title;
        Description = description;
    }

}