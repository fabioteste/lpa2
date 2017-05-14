using System;
using FluentValidator;
using LPA2.Shared.Entities;

namespace LPA2.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string firstName, string lastName, string email, User user)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
            Email = email;
            User = user;
            
            //Validacoes
            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName, "Nome é obrigatorio")
                .HasMaxLenght(x => x.FirstName, 60, "Nome nao pode ter mais de 60 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "Nome deve ter no minimo 3 caracteres")
                .IsRequired(x => x.LastName, "Sobrenome é obrigatorio")
                .HasMaxLenght(x => x.LastName, 60, "Sobrenome nao pode ter mais de 60 caracteres")
                .HasMinLenght(x => x.LastName, 3, "Sobrenome deve ter no minimo 3 caracteres")
                .IsEmail(x => x.Email, "Email inválido");
        }
        
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
