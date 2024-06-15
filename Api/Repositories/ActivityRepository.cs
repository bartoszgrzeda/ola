using Api.DbContexts;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class ActivityRepository
{
    private readonly ActivityDbContext _dbContext;
    private readonly DbSet<Activity> _activities;

    public ActivityRepository(ActivityDbContext dbContext)
    {
        _dbContext = dbContext;
        _activities = dbContext.Set<Activity>();
    }

    public void Add(Activity activity)
    {
        _activities.Add(activity);
    }

    public void Update(Activity activity)
    {
        _activities.Update(activity);
    }

    public void Delete(Activity activity)
    {
        _activities.Remove(activity);
    }

    public Task<Activity?> GetById(Guid id)
    {
        return _activities.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Activity>> GetAll()
    {
        return _activities.ToListAsync();
    }

    public Task Save()
    {
        return _dbContext.SaveChangesAsync();
    }
}