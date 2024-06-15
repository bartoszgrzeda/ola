namespace Api.Commands;

public class DeleteActivity
{
    public Guid Id { get; }

    public DeleteActivity(Guid id)
    {
        Id = id;
    }
}