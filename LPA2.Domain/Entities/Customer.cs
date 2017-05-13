using System;

namespace LPA2.Domain.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName, string email, User user)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
            Email = email;
            User = user;

            //VAlidacoes

        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }

        public void Update(string firstName, string lastname, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastname;
            BirthDate = birthDate;
        }


        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}
