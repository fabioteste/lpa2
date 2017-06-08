using System;
using LPA2.Domain.Entities;
using LPA2.Domain.Commands.Results;

namespace LPA2.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);

        Customer GetByUsername(string username);

        GetProductListCommandResult Get(string username);

        void Update(Customer customer);

        bool DocumentExists(string document);

        void Save(Customer customer);
         
    }
}
