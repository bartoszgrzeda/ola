using Api.Common;

namespace Api.Dtos;

public class ActivityDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public ActivityPriority Priority { get; set; }
}