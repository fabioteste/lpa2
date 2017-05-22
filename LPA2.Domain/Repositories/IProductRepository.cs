using System;
using LPA2.Domain.Entities;

namespace LPA2.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
    }
}
