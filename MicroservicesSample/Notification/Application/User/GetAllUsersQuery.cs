using System.Collections.Generic;
using MediatR;

namespace Notification.Application.User
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
        
    }
}