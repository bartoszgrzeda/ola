using Api.Common;

namespace Api.Commands;

public class CreateActivity
{
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }
    public ActivityPriority Priority { get; }

    public CreateActivity(string title, string description, DateTime dueDate, ActivityPriority priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
    }
}