using Api.Common;
using Api.Dtos;

namespace Api.Entities;

public class Activity
{
    public Guid Id { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public ActivityPriority Priority { get; private set; }

    public Activity(Guid id, string title, string description, DateTime dueDate, ActivityPriority priority)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
    }

    public void Update(string title, string description, DateTime dueDate, ActivityPriority priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
    }

    public ActivityDto ToDto()
    {
        return new ActivityDto()
        {
            Priority = Priority,
            Description = Description,
            DueDate = DueDate,
            Id = Id,
            Title = Title
        };
    }
}