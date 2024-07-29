using Microsoft.EntityFrameworkCore;
namespace Catalog.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) {
            CatalogInitialData CD = new CatalogInitialData(this);
        }
        public DbSet<Product> Products { get; set; }
    }
}