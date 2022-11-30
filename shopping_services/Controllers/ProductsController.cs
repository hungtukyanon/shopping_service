using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping_services.Models;
using shopping_services.Services.ProductService;

namespace shopping_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ProductModel productModel)
        {
            Console.WriteLine(productModel);

            try
            {
                Console.WriteLine("Render........");
                return Ok(_productRepository.Create(productModel));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(string id)
        {
            if (string.IsNullOrEmpty(id)) { return BadRequest(); }
            try
            {
                return Ok(_productRepository.GetById(id));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) { return BadRequest(); }
            try
            {
                return Ok(_productRepository.DeleteById(id));
            }
            catch { return BadRequest(); }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, ProductModel productModel)
        {
            if (string.IsNullOrEmpty(id)) { return BadRequest(); }

            try
            {
                return Ok(_productRepository.UpdateById(id, productModel));
            }
            catch { return BadRequest(); }
        }

        [HttpGet("/search")]
        public IActionResult SearchProduct(string? name, float? from, float? to)
        {
            try
            {
                return Ok(_productRepository.Search(name, from, to));
            }
            catch { return BadRequest(); }
        }

        [HttpGet("/page")]
        public IActionResult PageProduct(int page)
        {
            try
            {
                return Ok(_productRepository.PagingPage(page));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
