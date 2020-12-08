using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Customer.EntityFramework
{
    public class Repository : IRepository
    {
        private readonly DbSet<Domain.Customer> _dbSet;

        public Repository(CustomerDbContext customerDbContext)
        {
            _dbSet = customerDbContext.Set<Domain.Customer>();
        }

        public Task<Domain.Customer> GetById(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Domain.Customer>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<Domain.Customer> Add(Domain.Customer entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public Task<Domain.Customer> Update(Domain.Customer entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }
    }
}