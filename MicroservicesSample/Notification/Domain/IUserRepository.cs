using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notification.Application.User;

namespace Notification.Domain
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
        Task<List<UserDto>> GetAll();
        Task<User> Add(User user);
        Task<User> Update(User user);
    }
}