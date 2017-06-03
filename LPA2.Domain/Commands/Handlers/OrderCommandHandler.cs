using FluentValidator;
using LPA2.Domain.Commands.Inputs;
using LPA2.Domain.Commands.Results;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Shared.Commands;

namespace LPA2.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        private readonly CustomerHandler _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(CustomerHandler customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(RegisterOrderCommand command)
        {
            //instancia o cliente
            var customer = _customerRepository.Get(command.Customer);

            //gera novo pedido
            var order = new Order(customer, command.DeliveryFee, command.Discount);

            //adiciona itens no pedido
            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));

            }

            //adiciona notificacoes no pedido
            AddNotifications(order.Notifications);

            //persiste no banco
            if (IsValid())
                _orderRepository.Save(order);

            return new RegisterOrderCommandResult(order.Number);
        }
    }
}
