using System.Threading.Tasks;

namespace Identity.EntityFramework
{
    public interface IApplicationDbInitalizer
    {
        Task MigrateAll();
    }
}