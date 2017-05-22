using System;
using System.Collections.Generic;
using LPA2.Domain.Commands;
using LPA2.Domain.CommandsHandler;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Domain.ValueObjects;

namespace LPA2
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new RegisterOrderCommand
            {
                Customer = Guid.NewGuid(),
                DeliveryFee = 9,
                Discount = 30,
                Items = new List<RegisterOrderItemCommand>
                {
                    new RegisterOrderItemCommand
                    {
                        Product = Guid.NewGuid(),
                        Quantity = 3
                    }
                }
                
            };
            generateOrder(
                new FakeCustomerRepository(), 
                new FakeProductRepository(),
                new FakeOrderRepository(), 
                command);
            Console.ReadKey();


        }

        public static void generateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            RegisterOrderCommand command)
        {
            var handler = new OrderCommandHandler(
                customerRepository, 
                productRepository, 
                orderRepository);    
            handler.Handle(command);

            if(handler.IsValid())
                Console.WriteLine("Pedido cadastrado com sucesso!");



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

    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            
        }
    }
}
