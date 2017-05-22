using System;
using System.Collections.Generic;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Domain.ValueObjects;

namespace LPA2
{
    class Program
    {
        static void Main(string[] args)
        {
            generateOrder(
                new FakeCustomerRepository(), 
                new FakeProductRepository(), 
                new Guid(),
                new Dictionary<Guid, int> {{Guid.NewGuid(), 5}},
                10,
                20
                );
            Console.ReadKey();


        }

        public static void generateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            Guid userId, 
            IDictionary<Guid, int> items,
            decimal deliveryFee,
            decimal discount)
        {
            var customer = customerRepository.GetByUserId(userId);
            var order = new Order(customer, deliveryFee, discount);
            foreach (var item in items)
            {
                var product = productRepository.Get(item.Key);
                order.AddItem(new OrderItem(product, item.Value));

            }
            
            Console.WriteLine($"Número do pedido: { order.Number}");
            Console.WriteLine($"Data: {order.CreateDate: dd/MM/yyyy}");
            Console.WriteLine($"Desconto: {order.Discount}");
            Console.WriteLine($"Taxa de Entrega: {order.DeliveryFee}");
            Console.WriteLine($"Sub Total: {order.Subtotal()}");
            Console.WriteLine($"Total: {order.Total()}");
            Console.WriteLine($"Cliente: {order.Customer.Name.ToString()}");

        }
    }

    public class FakeProductRepository : IProductRepository
    {
        public Product Get(Guid id)
        {
            return new Product("mouse", 299, "mouse.jpg", 20);
        }
    }

    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(Guid id)
        {
            return null;
        }

        public Customer GetByUserId(Guid id)
        {
            return new Customer(
                new Name("Fabio", "Rezende"),
                new Email("fabio.rezende@gmail.com"),
                new Document("26648030348"),
                new User("fabiorezende", "senha") );
        }
    }
}
