using LPA2.Shared.Commands;

namespace LPA2.Domain.Commands.Inputs
{
    public class AuthenticateUserCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
