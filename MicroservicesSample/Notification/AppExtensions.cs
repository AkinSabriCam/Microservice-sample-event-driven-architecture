using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Notification.EntityFramework;

namespace Notification
{
    public static class AppExtensions
    {
        public static Task MigrateAll(this IServiceProvider serviceProvider)
        {
            var dbInitializer = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IDatabaseInitializer>();
            return dbInitializer.MigrateAll();
        }
    }
}