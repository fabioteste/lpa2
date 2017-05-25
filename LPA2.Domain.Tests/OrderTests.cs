using LPA2.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LPA2.Domain.Tests
{
    //[TestClass]
    //[TestCategory("Order - New Order")]
    //public class OrderTests
    //{
    //    private readonly Customer _customer = new Customer("Fabio", "Rezende", "fabio.rezende@gmail.com", new User("fabiorezende", "senha"));


    //    [TestMethod]
    //    public void GivenAnOutOfStockProductItShouldReturnAnError()
    //    {
    //        var mouse = new Product("Mouse", 299, "mouse.jpg", 0);

    //        var order = new Order(_customer, 8, 10);
    //        order.AddItem(new OrderItem(mouse, 2));

    //        Assert.IsFalse(order.IsValid());
    //    }

    //    [TestMethod]
    //    public void GivenAnInStockProductItShouldUpdateQuantityOnHand()
    //    {
    //        var mouse = new Product("Mouse", 299, "mouse.jpg", 20);

    //        var order = new Order(_customer, 8, 10);
    //        order.AddItem(new OrderItem(mouse, 2));

    //        Assert.IsTrue(mouse.QuantityOnHand == 18);
    //    }

    //    [TestMethod]
    //    public void GivenAValidOrderItShouldReturn()
    //    {
    //        var mouse = new Product("Mouse", 300, "mouse.jpg", 20);

    //        var order = new Order(_customer, 12, 2);
    //        order.AddItem(new OrderItem(mouse, 1));

    //        Assert.IsTrue(order.Total() == 310);
    //    }

    //}
}
