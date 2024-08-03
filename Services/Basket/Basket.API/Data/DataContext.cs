using Microsoft.EntityFrameworkCore;
namespace Basket.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) {
        }
        public DbSet<ShoppingCartItem> SCartItem { get; set; }
        public DbSet<ShoppingCart> SCart { get; set; }
    }
}