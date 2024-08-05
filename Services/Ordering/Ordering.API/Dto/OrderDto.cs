namespace Ordering.API.Dto;

public class OrderDto
{
    public string BuyerId { get; set; }
    public ShippingAddress Address { get; set; }
    public string OrderDate { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public string OrderStatus { get; set; }
    public decimal Total { get; set; }
}
