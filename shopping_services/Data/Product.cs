namespace shopping_services.Data
{
    public class Product
    {
        public Guid product_id { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string name { get; set; }
        public string? description { get; set; }
        //[Range(0, double.MinValue)]
        public double price { get; set; }
        public byte? discount { get; set; }
        //public string? category_id { get; set; }
        //[ForeignKey("category_id")]
        //public Category Category { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
