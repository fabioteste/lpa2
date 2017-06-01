using System;
using System.Data.Entity;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Infra.Contexts;
using System.Linq;

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
    }
}
