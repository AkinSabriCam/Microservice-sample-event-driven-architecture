using System;
using System.Threading.Tasks;
using Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Identity
{
    public static class AppServiceExtension
    {
        public static Task MigrateAll(this IServiceProvider serviceProvider)
        {
                var dbContextInitializer = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope()
                    .ServiceProvider.GetRequiredService<IApplicationDbInitalizer>();
                return dbContextInitializer.MigrateAll();
        }
    }
}