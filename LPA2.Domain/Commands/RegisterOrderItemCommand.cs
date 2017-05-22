using System;
using LPA2.Shared.Commands;

namespace LPA2.Domain.Commands
{
    public class RegisterOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}
