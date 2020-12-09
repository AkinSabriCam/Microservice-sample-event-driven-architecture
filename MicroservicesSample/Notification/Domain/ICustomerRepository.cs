using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notification.Application.Customer;

namespace Notification.Domain
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(Guid id);

        Task<List<CustomerDto>> GetAll();
        
        Task<Customer> Add(Customer entity);

        Task<Customer> Update(Customer entity);
    }
}