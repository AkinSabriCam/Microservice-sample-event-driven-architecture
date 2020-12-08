using System.Threading.Tasks;

namespace Customer.EntityFramework
{
    public interface IDatabaseInitializer
    {
        Task MigrateAll();
    }
}