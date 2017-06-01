using System;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Infra.Contexts;
using System.Linq;

namespace LPA2.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LPA2DataContext _context;

        public ProductRepository(LPA2DataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context
                .Products
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
