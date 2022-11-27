using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_services.Data
{
    public class Category
    {
        public Guid category_id { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string name { get; set; }
        public Guid? product_id { get; set; }
        public Product Product { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
