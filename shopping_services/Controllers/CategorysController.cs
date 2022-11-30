using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping_services.Models;
using shopping_services.Services.CategoryService;

namespace shopping_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategorysController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                return Ok(_categoryRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(string id)
        {
            try
            {
                return Ok(_categoryRepository.GetbyId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            //Guid guid = Guid.NewGuid();
            try
            {
                return Ok(_categoryRepository.PostCategory(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                return Ok(_categoryRepository.DeleteCategory(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, CategoryModel category)
        {

            try
            {
                return Ok(_categoryRepository.PutCategory(id, category));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
