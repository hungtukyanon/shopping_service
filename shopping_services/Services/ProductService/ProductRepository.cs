using Microsoft.AspNetCore.Http.HttpResults;
using shopping_services.Data;
using shopping_services.Models;

namespace shopping_services.Services.ProductService
{
    public class ProductRepository : IProductRepository
    {
        private readonly FE_DbContext _context;
        public ProductRepository(FE_DbContext context)
        {
            _context = context;
        }

        public string DeleteById(string id)
        {
            var product = _context.Product.FirstOrDefault(p => p.product_id.ToString() == id);
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
                return "Delete Product successfully";
            }
            return "Not Found Product";
        }

        public List<ProductModel> GetAll()
        {
            var products = _context.Product.Select(x => new ProductModel
            {
                product_id = x.product_id,
                name = x.name,
                price = x.price,
                description = x.description,
                discount = x.discount,
            });

            return products.ToList();
        }

        public ProductModel GetById(string id)
        {
            var product = _context.Product.FirstOrDefault(p => p.product_id.ToString() == id);
            if (product != null)
            {
                return new ProductModel
                {
                    name = product.name,
                    price = product.price,
                    description = product.description,
                    discount = product.discount,
                };
            }
            return null;
        }

        public string UpdateById(string id, ProductModel productModel)
        {
            var product = _context.Product.FirstOrDefault(p => p.product_id.ToString() == id);
            if (product != null)
            {
                product.name = productModel.name;
                product.price = productModel.price;
                product.description = productModel.description;
                product.discount = productModel.discount;

                _context.SaveChanges();

                return "OK";
            }

            return "Update Fail";
        }


        public List<ProductModel> Search(string? name, float? from, float? to)
        {
            var products = _context.Product.AsEnumerable();

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.name.Contains(name));
            }
            if (from.HasValue)
            {
                products = products.Where(p => p.price >= from);
            }
            if (to.HasValue)
            {
                products = products.Where(p => p.price <= to);
            }

            var result = products.Select(p => new ProductModel
            {
                product_id = p.product_id,
                name = p.name,
                description = p.description,
                price = p.price,
                discount = p.discount
            });

            return result.ToList();
        }

        public List<ProductModel> PagingPage(int page)
        {
            var products = _context.Product.Select(p => new ProductModel
            {
                product_id = p.product_id,
                name = p.name,
                description = p.description,
                price = p.price,
                discount = p.discount
            }).Skip((page - 1) * 5).Take(5);

            return products.ToList();
        }

        public string Create(ProductModel model)
        {
            Console.WriteLine(model);
            var product = new Product
            {
                name = model.name,
                description = model.description,
                price = model.price,
                discount = model.discount,
            };

            //_context.Product.Add(product);
            _context.Add(product);
            _context.SaveChanges();

            return "Create product successfully";
        }
    }
}
