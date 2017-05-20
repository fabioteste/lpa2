using System;
using LPA2.Domain.Entities;
using LPA2.Domain.ValueObjects;

namespace LPA2
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = new Name("Fabio", "Rezende");
            var email = new Email("fabio.rezende@gmail.com");
            var document = new Document("90710919964");
            var user = new User("fabiorezende", "senha");
            var customer = new Customer(name, email, document, user);
            var mouse = new Product("Mouse", 299, "mouse.jpg", 20);
            var mousepad = new Product("Mousepad", 99, "mousepad.jpg", 20 );
            var teclado = new Product("Teclado", 599, "teclado.jpg", 20);

            Console.WriteLine($"Mouse: {mouse.QuantityOnHand}");
            Console.WriteLine($"Mousepad: {mousepad.QuantityOnHand}");
            Console.WriteLine($"Teclado: {teclado.QuantityOnHand}");

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(mousepad, 2));
            order.AddItem(new OrderItem(teclado, 2));

            Console.WriteLine($"Número do pedido: { order.Number}");
            Console.WriteLine($"Data: {order.CreateDate: dd/MM/yyyy}");
            Console.WriteLine($"Desconto: {order.Discount}");
            Console.WriteLine($"Taxa de Entrega: {order.DeliveryFee}");
            Console.WriteLine($"Sub Total: {order.Subtotal()}");
            Console.WriteLine($"Total: {order.Total()}");
            Console.WriteLine($"Cliente: {order.Customer.Name.ToString()}");

            Console.WriteLine($"Mouse: {mouse.QuantityOnHand}");
            Console.WriteLine($"Mousepad: {mousepad.QuantityOnHand}");
            Console.WriteLine($"Teclado: {teclado.QuantityOnHand}");

            Console.ReadKey();


        }
    }
}
