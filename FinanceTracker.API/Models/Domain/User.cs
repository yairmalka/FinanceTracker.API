﻿namespace FinanceTracker.API.Models.Domain
{
    public class User
    {

        public class User
        {
            public Guid Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public string FullName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
