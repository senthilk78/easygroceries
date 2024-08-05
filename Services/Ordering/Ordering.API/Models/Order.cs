namespace Ordering.API.Models;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string BuyerId { get; set; }
    public string OrderDate { get; set; }
    public Guid ShippingAddressID { get; set; }
    public List<Guid> OrderItemIds { get; set; }
    public string OrderStatus { get; set; }
    public decimal Total { get; set; }
}
