using Api.Entities;

namespace Api.Repositories;

public class ActivityRepository
{
    private readonly List<Activity> _activities;

    public ActivityRepository()
    {
        _activities = new List<Activity>();
    }

    public void Add(Activity activity)
    {
        _activities.Add(activity);
    }

    public void Update(Activity activity)
    {
        var existingActivity = _activities.RemoveAll(x => x.Id == activity.Id);
        _activities.Add(activity);
    }

    public void Delete(Activity activity)
    {
        _activities.Remove(activity);
    }

    public Task<Activity?> GetById(Guid id)
    {
        return Task.FromResult(_activities.SingleOrDefault(x => x.Id == id));
    }

    public Task<List<Activity>> GetAll()
    {
        return Task.FromResult(_activities);
    }

    public Task Save()
    {
        return Task.CompletedTask;
    }
}