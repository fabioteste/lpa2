using System;
using LPA2.Domain.Entities;
using LPA2.Domain.Commands.Results;
using System.Collections.Generic;

namespace LPA2.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);

        IEnumerable<GetProductListCommandResult> Get();
    }
}
