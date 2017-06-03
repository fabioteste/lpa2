using LPA2.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LPA2.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/products")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }
    }
}
