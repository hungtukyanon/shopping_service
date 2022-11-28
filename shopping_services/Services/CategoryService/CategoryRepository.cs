using Microsoft.AspNetCore.Http.HttpResults;
using shopping_services.Data;
using shopping_services.Models;

namespace shopping_services.Services.CategoryService
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FE_DbContext _context;
        public CategoryRepository(FE_DbContext context)
        {
            _context = context;
        }

        public string DeleteCategory(string id)
        {
            var category = _context.Categorie.FirstOrDefault(c => c.category_id.ToString() == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();

                return "Delete succesfully!";
            }
            return "Not Found Category!";

        }

        public List<CategoryVM> GetAll()
        {
            var categorys = _context.Categorie.Select(c => new CategoryVM
            {
                category_id = c.category_id,
                name = c.name,
            });

            return categorys.ToList();
        }

        public CategoryVM GetbyId(string id)
        {
            var category = _context.Categorie.FirstOrDefault(c => c.category_id.ToString() == id);
            if (category != null)
            {
                return new CategoryVM
                {
                    category_id = category.category_id,
                    name = category.name,
                };
            }
            return null;
        }

        public string PostCategory(CategoryModel categoryModel)
        {
            var category = new Category
            {
                name = categoryModel.name,
            };

            _context.Add(category);
            _context.SaveChanges();

            return "Create category successfully!";
        }

        public string PutCategory(string id, CategoryModel category)
        {
            var _category = _context.Categorie.FirstOrDefault(c => c.category_id.ToString() == id);

            if (_category != null)
            {
                _category.name = category.name;
                //_context.CategoryModel.Add(category);
                //_context.
                _context.SaveChanges();
            }

            return "Update category successfully!";

            //return NotFound();
        }
    }
}
