using Blog.Service.New.EntityFramework.Core.DbContexts;
using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Service.New.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>();
        }, "Blog.Service.New.Database.Migrations");
    }
}
