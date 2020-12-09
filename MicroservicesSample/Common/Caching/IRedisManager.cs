using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Common.Caching
{
    public interface IRedisManager
    {
        Task<bool> SetAsync<T>(string key, T value, TimeSpan? expires = default,
            When when = When.Always, CommandFlags flags = CommandFlags.None);
        Task<T> GetAsync<T>(string key);
        Task<T> GetOrRun<T>(string key, Func<Task<T>> action);
        Task<bool> DeleteAsync(string key);
    }
}