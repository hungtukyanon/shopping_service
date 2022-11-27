using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopping_services.Data;
using shopping_services.Models;

namespace shopping_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly FE_DbContext _context;

        public CategorysController(FE_DbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var categorys = _context.Categorie.ToList();

            return Ok(categorys);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            //Guid guid = Guid.NewGuid();
            try
            {
                var model = new Category
                {
                    //category_id = Guid.NewGuid().ToString(),
                    name = category.name
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
    }
}
