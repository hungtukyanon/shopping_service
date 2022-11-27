using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_services.Data
{
    public class OrderDetail
    {
        // Private order_id
        public Guid order_id { get; set; }
        public Order Order { get; set; }
        // Private product_id
        public Guid product_id { get; set; }
        public Product Product { get; set; }

        public int quantity { get; set; }
        public double totalMoney { get; set; }
        public byte discount { get; set; }
    }
}
