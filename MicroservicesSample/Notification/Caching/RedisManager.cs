using System;
using System.Threading.Tasks;
using Common.Caching;
using StackExchange.Redis;

namespace Notification.Caching
{
    public class RedisManager : IRedisManager
    {
        public Task<bool> SetAsync<T>(string key, object identifier, T value, TimeSpan? expires = default, When when = When.Always,
            CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task GetAsync(string key, object identifier)
        {
            throw new NotImplementedException();
        }

        public Task GetOrRun<T>(string key, object identifier, Func<Task<T>> action)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string key, object identifier)
        {
            throw new NotImplementedException();
        }
    }
}