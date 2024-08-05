namespace Ordering.API.Models;

public class OrderItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
