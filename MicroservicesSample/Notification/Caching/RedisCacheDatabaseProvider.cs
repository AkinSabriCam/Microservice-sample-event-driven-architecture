using System;
using Common.Caching;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Notification.Caching
{
    public class RedisCacheDatabaseProvider : IRedisCacheDatabaseProvider
    {
        private readonly RedisSettingsModel _settings;
        private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer;

        public RedisCacheDatabaseProvider(IOptions<RedisSettingsModel> settings)
        {
            _settings = settings.Value;
            _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(CreateConnectionMultiplexer);
        }

        public IDatabase GetDatabase()
        {
            return _connectionMultiplexer.Value.GetDatabase(_settings.DefaultDatabase);
        }
        
        private ConnectionMultiplexer CreateConnectionMultiplexer()
        {
            var config = GetConfigurationOptions(this._settings);
            return ConnectionMultiplexer.Connect(config);
        }

        private static ConfigurationOptions GetConfigurationOptions(RedisSettingsModel redisOptions)
        {
            return new ConfigurationOptions
            {
                EndPoints = {redisOptions.EndPoint},
                Password = redisOptions.Password,
                AllowAdmin = true,
                DefaultDatabase = redisOptions.DefaultDatabase,
                KeepAlive = 60,
                SyncTimeout = redisOptions.SyncTimeout,
                ConnectTimeout = redisOptions.ConnectTimeout
            };
        }
    }
}