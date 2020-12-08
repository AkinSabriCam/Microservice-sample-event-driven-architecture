using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Domain
{
    public interface IRepository
    {
        Task<Customer> GetById(Guid id);
        Task<List<Customer>> GetAll();
        Task<Customer> Add(Customer entity);
        Task<Customer> Update(Customer entity);
    }
}