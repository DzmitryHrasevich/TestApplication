using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace Tests.Services;

public abstract class BaseTests
{
    protected ApplicationDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
            .Options;
        return new ApplicationDbContext(options);
    }
}