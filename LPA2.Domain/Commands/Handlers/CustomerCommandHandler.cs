using FluentValidator;
using LPA2.Domain.Commands.Inputs;
using LPA2.Domain.Commands.Results;
using LPA2.Domain.Entities;
using LPA2.Domain.Repositories;
using LPA2.Domain.Resources;
using LPA2.Domain.Services;
using LPA2.Domain.ValueObjects;
using LPA2.Shared.Commands;

namespace LPA2.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<RegisterCustomerCommand>
    {
        private readonly CustomerHandler _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(CustomerHandler customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            //1 - Verificar se o cpf ja existe
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Customer", "Este CPF já está em uso.");
                return null;
            }

            //2 - Gerar o novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email,document,user);

            //3 Adicionando Notificacoes
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            if (!IsValid())
                return null;

            //4 Inserir no banco
            _customerRepository.Save(customer);

            //5 Enviar email de boas vindas
            _emailService.Send(
                customer.Name.ToString(), 
                customer.Email.Address, 
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name), 
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));

            //6 Retornar algo
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
