using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Domain;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework
{
    public class Repository : IRepository
    {
        private readonly DbSet<User> _dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _dbSet = applicationDbContext.Set<User>();
        }

        public Task<User> GetById(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<User>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<User> Add(User entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public Task<User> Update(User entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }
    }
}