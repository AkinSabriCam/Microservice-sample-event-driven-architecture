using System;
using System.Threading.Tasks;
using Customer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Customer
{
    public static class ApplicationExtensions
    {
        public static Task MigrateAll(this IServiceProvider serviceProvider)
        {
            var dbInitializer = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IDatabaseInitializer>();
            return dbInitializer.MigrateAll();
        }
    }
}