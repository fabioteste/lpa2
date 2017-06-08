using System;
using System.Data.Entity;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Infra.Contexts;
using System.Linq;
using LPA2.Domain.Commands.Results;
using System.Data.SqlClient;
using Dapper;

namespace LPA2.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LPA2DataContext _context;

        public CustomerRepository(LPA2DataContext context)
        {
            _context = context;
        }

        public Customer Get(Guid id)
        {
            return _context
                .Customers
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public Customer GetByUsername(string username)
        {
            return _context
                .Customers
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefault(x => x.User.Username == username);
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public GetProductListCommandResult Get(string username)
        {
            //return _context
            //    .Customers
            //    .Include(x => x.User)
            //    .AsNoTracking()
            //    .Select(x => new GetCustomerCommandResult
            //    {
            //        Name = x.Name.ToString(),
            //        Document = x.Document.Number,
            //        Active = x.User.Active,
            //        Email = x.Email.Address,
            //        Password = x.User.Password,
            //        Username = x.User.Username

            //    }).FirstOrDefault(x => x.Username == username);
            var query = "SELECT * FROM [GetCustomerInfoView] WHERE [Active] = 1 AND [Username] = @username";
            using (var conn = new SqlConnection(@"Server=DORMAMU;Database=LPA2; User ID=sa; Password=sqlexpress;"))
            {
                conn.Open();
                return conn
                    .Query<GetProductListCommandResult>(query,
                    new { username = username })
                    .FirstOrDefault();

            }
        }
    }
}
