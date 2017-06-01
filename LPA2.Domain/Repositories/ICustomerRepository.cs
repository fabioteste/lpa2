using System;
using LPA2.Domain.Entities;

namespace LPA2.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);

        void Update(Customer customer);

        bool DocumentExists(string document);

        void Save(Customer customer);
    }
}
