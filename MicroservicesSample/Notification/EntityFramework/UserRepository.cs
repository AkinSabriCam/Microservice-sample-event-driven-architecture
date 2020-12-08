using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notification.Domain;

namespace Notification.EntityFramework
{
    public class UserRepository :IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(NotificationDbContext dbContext)
        {
            _dbSet = dbContext.Set<User>();
        }
        
        public Task<User> GetById(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<User>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<User> Add(User user)
        {
            var result = await _dbSet.AddAsync(user);
            return result.Entity;
        }

        public Task<User> Update(User user)
        {
            _dbSet.Update(user);
            return Task.FromResult(user);
        }
    }
}