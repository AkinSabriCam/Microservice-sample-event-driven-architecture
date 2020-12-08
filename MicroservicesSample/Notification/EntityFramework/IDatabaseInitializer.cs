using System.Threading.Tasks;

namespace Notification.EntityFramework
{
    public interface IDatabaseInitializer
    {
        Task MigrateAll();
    }
}