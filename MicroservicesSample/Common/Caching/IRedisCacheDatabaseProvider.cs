using System.Threading.Tasks;
using StackExchange.Redis;

namespace Common.Caching
{
    public interface IRedisCacheDatabaseProvider
    {
        IDatabase GetDatabase();
    }
}