using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping_services.Data
{
    public enum orderStatus
    {
        NOTDELIVERED = 0,
        DELIVERED = 1
    }
    public class Order
    {
        public Guid order_id { get; set; }
        public string orderer { get; set; }
        public string phone { get; set; }
        public string deliveryAddress { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime? deliveryDate { get; set; }
        public orderStatus orderStatus { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
