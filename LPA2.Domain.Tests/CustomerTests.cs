using LPA2.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LPA2.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User _user = new User("fabiorezende", "senha");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAInvalidFirstNameShouldReturnANotification()
        {
            var customer = new Customer("", "Rezende", "fabio.rezende@gmail.com", _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAInvalidLastNameShouldReturnANotification()
        {
            var customer = new Customer("Fabio", "", "fabio.rezende@gmail.com", _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAInvalidEmailShouldReturnANotification()
        {
            var customer = new Customer("Fabio", "Rezende", "f", _user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
