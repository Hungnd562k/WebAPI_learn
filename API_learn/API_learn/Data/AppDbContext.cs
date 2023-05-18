using Microsoft.EntityFrameworkCore;

namespace API_learn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasKey(ord => ord.OrderId);
                e.Property(ord => ord.DeliveryDate).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(e => new { e.ProductId, e.OrderId });

                e.HasOne(e => e.Order)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                e.HasOne(e => e.Product)
                    .WithMany(e => e.OrderDetails)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_orderdetail_product");
            });
        }
    }
}
