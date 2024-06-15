using Api.Common;
using Api.Dtos;
using Api.Entities;
using Api.Exceptions;
using Api.Repositories;

namespace Api.Services;

public class ActivityService
{
    private readonly ActivityRepository _repository;

    public ActivityService(ActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Create(string title, string description, DateTime dueDate, ActivityPriority priority)
    {
        var id = Guid.NewGuid();
        var activity = new Activity(Guid.NewGuid(), title, description, dueDate, priority);

        _repository.Add(activity);
        await _repository.Save();

        return id;
    }

    public async Task Update(Guid id, string title, string description, DateTime dueDate, ActivityPriority priority)
    {
        var activity = await _repository.GetById(id);

        if (activity is null)
        {
            throw new NotFound();
        }

        activity.Update(title, description, dueDate, priority);

        _repository.Update(activity);
        await _repository.Save();
    }

    public async Task Delete(Guid id)
    {
        var activity = await _repository.GetById(id);

        if (activity is null)
        {
            throw new NotFound();
        }

        _repository.Delete(activity);
        await _repository.Save();
    }

    public async Task<ActivityDto> GetById(Guid id)
    {
        var activity = await _repository.GetById(id);

        if (activity is null)
        {
            throw new NotFound();
        }

        return activity.ToDto();
    }

    public async Task<List<ActivityDto>> GetAll()
    {
        var activities = await _repository.GetAll();

        return activities.Select(x => x.ToDto()).ToList();
    }
}