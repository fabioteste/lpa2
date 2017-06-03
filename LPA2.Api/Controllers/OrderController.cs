using LPA2.Domain.Commands.Handlers;
using LPA2.Domain.Commands.Inputs;
using LPA2.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LPA2.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderCommandHandler _handler;

        public OrderController(IUow uow, OrderCommandHandler handler)
            : base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/orders")]
        public async Task<IActionResult> Post([FromBody]RegisterOrderCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}
