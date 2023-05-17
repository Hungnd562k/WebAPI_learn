using Microsoft.EntityFrameworkCore;

namespace API_learn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        #endregion
    }
}
