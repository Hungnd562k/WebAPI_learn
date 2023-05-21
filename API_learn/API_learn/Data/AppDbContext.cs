using Microsoft.EntityFrameworkCore;

namespace API_learn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<User> Users { get; set; }
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

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(e => e.UserId);
                e.HasIndex(e => e.UserName).IsUnique();
                e.Property(e => e.UserName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Password).HasMaxLength(15).IsRequired();
                e.Property(e => e.FullName).HasMaxLength(50).IsRequired();
                e.Property(e => e.FullName).HasColumnType("nvarchar");
                e.Property(e => e.Email).HasMaxLength(50).IsRequired();
            });
        }
    }
}
