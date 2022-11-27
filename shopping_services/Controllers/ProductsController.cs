using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Internal.TypeHandlers;
using shopping_services.Data;
using shopping_services.Models;
using System;

namespace shopping_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly FE_DbContext _context;

        public ProductsController(FE_DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var listProduct = _context.Product.ToList();

            return Ok(listProduct);
        }


        //[HttpGet]
        //public IActionResult GetById(string id)
        //{

        //    var product = _context.products.SingleOrDefault(p => p.product_id == id);

        //    if (product != null)
        //    {
        //        return Ok(product);
        //    }
        //    else { return NotFound(); }
        //}

        [HttpPost]
        public IActionResult Create(ProductModel product)
        {
            //Guid guid = Guid.NewGuid();
            try
            {
                var model = new Product
                {
                    //product_id = Guid.NewGuid().ToString(),
                    name = product.name,
                    price = product.price,
                    discount = product.discount,
                    //category_id = product.category_id,
                };
                _context.Add(model);
                _context.SaveChanges();
                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //public IActionResult Update(int id, ProductDTO product)
        //{
        //    var findedProduct = _context.products.SingleOrDefault(p => p.product_id == id);

        //    if (findedProduct != null)
        //    {
        //        // Update product
        //        var model = new Product
        //        {
        //            name = product.name,
        //            price = product.price,
        //            discount = product.discount,
        //            category_id = product.category_id,
        //        };
        //        _context.Add(model);
        //        _context.SaveChanges();
        //        return Ok(product);
        //    }
        //    else { return NotFound(); }
        //}
    }
}
