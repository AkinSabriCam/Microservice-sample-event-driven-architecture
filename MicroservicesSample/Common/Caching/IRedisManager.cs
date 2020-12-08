using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Common.Caching
{
    public interface IRedisManager
    {
        Task<bool> SetAsync<T>(string key, object identifier, T value, TimeSpan? expires = default,
            When when = When.Always, CommandFlags flags = CommandFlags.None);
        Task GetAsync(string key, object identifier);
        Task GetOrRun<T>(string key, object identifier, Func<Task<T>> action);
        Task<bool> DeleteAsync(string key, object identifier);
    }
}