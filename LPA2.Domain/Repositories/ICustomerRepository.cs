using System;
using LPA2.Domain.Entities;

namespace LPA2.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);

        Customer GetByUserId(Guid id);

    }
}
