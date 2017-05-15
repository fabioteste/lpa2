using System;

namespace LPA2.Domain.Entities
{
    public class User
    {
        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Active = true;
        }

        public Guid Id { get; private set; }
        public String Username { get; private set; }
        public String Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;
    }
}
