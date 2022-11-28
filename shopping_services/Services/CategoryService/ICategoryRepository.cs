using shopping_services.Models;

namespace shopping_services.Services.CategoryService
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetbyId(string id);
        string PostCategory(CategoryModel categoryModel);
        string DeleteCategory(string id);
        string PutCategory(string id, CategoryModel category);
    }
}
