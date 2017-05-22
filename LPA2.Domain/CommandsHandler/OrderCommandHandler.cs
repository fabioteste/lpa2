using FluentValidator;
using LPA2.Domain.Commands;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Shared.Commands;

namespace LPA2.Domain.CommandsHandler
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public void Handle(RegisterOrderCommand command)
        {

            var customer = _customerRepository.Get(command.Customer);
            var order = new Order(customer, command.DeliveryFee, command.Discount);
            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));

            }

            AddNotifications(order.Notifications);

            if (order.IsValid())
                _orderRepository.Save(order);
        }
    }
}
