using FluentValidator;
using LPA2.Shared.Entities;

namespace LPA2.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected  OrderItem() { }
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 1)
                .IsGreaterThan(x => x.Product.QuantityOnHand, Quantity + 1, $"Temos apenas {product.QuantityOnHand} {product.Title} em estoque");

            Product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
