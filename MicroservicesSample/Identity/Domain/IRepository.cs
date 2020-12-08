using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain
{
    public interface IRepository
    {
        Task<User> GetById(Guid id);

        Task<List<User>> GetAll();
        Task<User> Add(User entity);

        Task<User> Update(User entity);
    }
}