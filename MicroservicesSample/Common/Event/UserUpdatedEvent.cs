﻿using System;

namespace Common.Event
{
    public class UserUpdatedEvent : IUserEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}