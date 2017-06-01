using System;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Infra.Contexts;
using System.Linq;
using LPA2.Domain.Commands.Results;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

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

        public IEnumerable<GetProductListCommandResult> Get()
        {
            var query = "SELECT [Id], [Title], [Price], [Image] FROM [Product]";
            using (var conn = new SqlConnection(@"Server=DORMAMU;Database=LPA2; User ID=sa; Password=sqlexpress;"))
            {
                conn.Open();
                return conn.Query<GetProductListCommandResult>(query);
            }
        }
    }
}
