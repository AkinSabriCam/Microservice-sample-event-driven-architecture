using System;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Caching;
using StackExchange.Redis;

namespace Notification.Caching
{
    public class RedisManager : IRedisManager
    {
        private readonly IDatabase _db;

        public RedisManager(IRedisCacheDatabaseProvider dbProvider)
        {
            _db = dbProvider.GetDatabase();
        }

        public Task<bool> SetAsync<T>(
            string key, T value, TimeSpan? expires = default, When when = When.Always,
            CommandFlags flags = CommandFlags.None)
        {
            return _db.StringSetAsync(key, JsonSerializer.Serialize(value), expires, when, flags);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var valueBytes = await _db.StringGetAsync(key, CommandFlags.PreferMaster);

            return !valueBytes.HasValue ? default(T) : JsonSerializer.Deserialize<T>(valueBytes);
        }

        public async Task<T> GetOrRun<T>(string key, Func<Task<T>> action)
        {
            var result = await GetAsync<T>(key);

            if (result == null)
            {
                var invokeResult = await action.Invoke();
                if (invokeResult != null)
                    await SetAsync(key, invokeResult);
                return invokeResult;
            }

            return result;
        }

        public Task<bool> DeleteAsync(string key)
        {
            return _db.KeyDeleteAsync(key);
        }
    }
}