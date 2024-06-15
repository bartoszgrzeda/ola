using Api.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MigrationController : ControllerBase
{
    private readonly ActivityDbContext _dbContext;

    public MigrationController(ActivityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public Task Migrate()
    {
        return _dbContext.Database.MigrateAsync();
    }
}