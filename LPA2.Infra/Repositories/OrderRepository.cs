using System;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Infra.Contexts;

namespace LPA2.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LPA2DataContext _context;

        public OrderRepository(LPA2DataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
