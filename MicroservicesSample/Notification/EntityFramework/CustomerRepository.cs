using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Caching;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Notification.Application.Customer;
using Notification.Domain;

namespace Notification.EntityFramework
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customer> _dbSet;
        private readonly IRedisManager _redisManager;

        public CustomerRepository(NotificationDbContext dbContext, IRedisManager redisManager)
        {
            _redisManager = redisManager;
            _dbSet = dbContext.Set<Customer>();
        }

        public Task<Customer> GetById(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<CustomerDto>> GetAll()
        {
            return _redisManager.GetOrRun(RedisKeyConsts.Customer,
                () => _dbSet.AsQueryable()
                    .ProjectToType<CustomerDto>().ToListAsync());
        }

        public async Task<Customer> Add(Customer entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await ClearRedisCache();
            return result.Entity;
        }

        public async Task<Customer> Update(Customer entity)
        {
            _dbSet.Update(entity);
            await ClearRedisCache();
            return entity;
        }

        private Task ClearRedisCache()
        {
            return _redisManager.DeleteAsync(RedisKeyConsts.Customer);
        }
    }
}