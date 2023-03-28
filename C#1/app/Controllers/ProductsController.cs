using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _repository.AddProduct(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _repository.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _repository.DeleteProduct(id);
            return Ok();
        }
    }
}
