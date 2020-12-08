using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification.Domain
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(Guid id);

        Task<List<Customer>> GetAll();
        
        Task<Customer> Add(Customer entity);

        Task<Customer> Update(Customer entity);
    }
}