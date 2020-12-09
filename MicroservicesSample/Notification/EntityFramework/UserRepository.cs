using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Caching;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Notification.Application.User;
using Notification.Domain;

namespace Notification.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _dbSet;
        private readonly IRedisManager _redisManager;

        public UserRepository(NotificationDbContext dbContext, IRedisManager redisManager)
        {
            _redisManager = redisManager;
            _dbSet = dbContext.Set<User>();
        }

        public Task<User> GetById(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<UserDto>> GetAll()
        {
            return _redisManager.GetOrRun(RedisKeyConsts.User,
                () => _dbSet.AsQueryable()
                    .ProjectToType<UserDto>()
                    .ToListAsync());
        }

        public async Task<User> Add(User user)
        {
            var result = await _dbSet.AddAsync(user);
            await ClearRedisCache();
            return result.Entity;
        }

        public async Task<User> Update(User user)
        {
            _dbSet.Update(user);
            await ClearRedisCache();
            return user;
        }

        private Task ClearRedisCache()
        {
            return _redisManager.DeleteAsync(RedisKeyConsts.User);
        }
    }
}