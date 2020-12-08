using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification.Domain
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
        Task<List<User>> GetAll();
        Task<User> Add(User user);
        Task<User> Update(User user);
    }
}