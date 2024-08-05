using Microsoft.EntityFrameworkCore;
using Ordering.API.Models;
namespace Ordering.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) {
        }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}