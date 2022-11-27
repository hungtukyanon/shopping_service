using Microsoft.EntityFrameworkCore;

namespace shopping_services.Data
{
    public class FE_DbContext: DbContext
    {
        public FE_DbContext(DbContextOptions options): base(options) { }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.ToTable("Category");
                c.HasKey("category_id");
                //c.Property(c => c.category_id).IsRequired();


                c.HasOne<Product>(c => c.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(p => p.product_id);
            });
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Product");
                p.HasKey("product_id");
            });
            modelBuilder.Entity<Order>(o =>
            {
                o.ToTable("Order");
                o.HasKey("order_id");
            });


            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(e => new { e.order_id, e.product_id });

                e.HasOne(e => e.Product)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.product_id);

                e.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.order_id);
            });
        }

        #region Dbset
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categorie { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Order { get; set; }
        #endregion

    }
}
