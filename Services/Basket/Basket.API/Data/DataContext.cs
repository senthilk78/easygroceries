using Microsoft.EntityFrameworkCore;
namespace Basket.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) {
        }
        public DbSet<ShoppingCartItem> SCart { get; set; }
    }
}