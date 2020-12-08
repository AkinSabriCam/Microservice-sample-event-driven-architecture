using System;

namespace Identity.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        
        public string Email { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}