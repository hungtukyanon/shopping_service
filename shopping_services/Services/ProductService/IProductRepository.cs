using shopping_services.Data;
using shopping_services.Models;

namespace shopping_services.Services.ProductService
{
    public interface IProductRepository
    {
        public List<ProductModel> GetAll(); 
        public ProductModel GetById(string id);
        public string DeleteById(string id);
        public string UpdateById(string id, ProductModel productModel);
        public string Create(ProductModel productModel);
        public List<ProductModel> Search(string? name, float? from, float? to);
        public List<ProductModel> PagingPage(int page);
    }
}
