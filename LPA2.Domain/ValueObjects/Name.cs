using FluentValidator;

namespace LPA2.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        protected Name() { }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName, "Nome é obrigatorio")
                .HasMaxLenght(x => x.FirstName, 60, "Nome nao pode ter mais de 60 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "Nome deve ter no minimo 3 caracteres")
                .IsRequired(x => x.LastName, "Sobrenome é obrigatorio")
                .HasMaxLenght(x => x.LastName, 60, "Sobrenome nao pode ter mais de 60 caracteres")
                .HasMinLenght(x => x.LastName, 3, "Sobrenome deve ter no minimo 3 caracteres");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
