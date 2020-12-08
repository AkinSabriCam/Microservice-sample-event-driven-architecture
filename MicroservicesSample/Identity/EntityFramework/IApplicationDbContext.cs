using System.Threading.Tasks;

namespace Identity.EntityFramework
{
    public interface IApplicationDbContext
    {
       Task MigrateAll();
    }
}