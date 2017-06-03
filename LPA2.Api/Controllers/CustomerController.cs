using LPA2.Domain.Commands.Handlers;
using LPA2.Domain.Commands.Inputs;
using LPA2.Domain.Repositories;
using LPA2.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LPA2.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;

        public CustomerController(IUow uow, CustomerCommandHandler handler)
            : base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/customers")]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}
