using System;
using LPA2.Domain.Entities;

namespace LPA2
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Fabio", "fabiorezende");
            var customer = new Customer("Fabio", "Rezende", "fabio.rezende@gmail.com", user);
            //customer.FirstName = "Arlindo";
            customer.User.Activate();
            Console.WriteLine(customer.ToString());
            Console.ReadKey();
        }
    }
}
