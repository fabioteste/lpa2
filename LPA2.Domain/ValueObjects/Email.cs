﻿using FluentValidator;

namespace LPA2.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string address)
        {
            Address = address;

            //Validacoes
            new ValidationContract<Email>(this)
                    .IsEmail(x => x.Address, "Email inválido");
        }

        public string Address { get; private set; }




    }
}
