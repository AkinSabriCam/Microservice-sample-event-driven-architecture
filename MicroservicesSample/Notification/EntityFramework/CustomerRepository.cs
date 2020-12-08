using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notification.Domain;

namespace Notification.EntityFramework
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(NotificationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Customer>();
        }
        
        public Task<Customer> GetById(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Customer>> GetAll()
        {
            return _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> Add(Customer entity)
        {
            var result =await _dbSet.AddAsync(entity); 
            return result.Entity;
        }

        public Task<Customer> Update(Customer entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }
    }
}