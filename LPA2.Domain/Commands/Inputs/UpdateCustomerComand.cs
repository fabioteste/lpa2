using System;
using LPA2.Shared.Commands;

namespace LPA2.Domain.Commands.Inputs
{
    public class UpdateCustomerComand : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
