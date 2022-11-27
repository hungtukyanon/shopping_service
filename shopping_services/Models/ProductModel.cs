using System.ComponentModel.DataAnnotations;

namespace shopping_services.Models
{
    public class ProductModel
    {
        public string name { get; set; }

        public string? description { get; set; }

        public double price { get; set; }

        public byte? discount { get; set; }

        public string? category_id { get; set; }
    }
}
