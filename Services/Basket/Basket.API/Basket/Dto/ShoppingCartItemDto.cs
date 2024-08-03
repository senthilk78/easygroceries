namespace Basket.API.Basket.Dto;

public class ShoppingCartItemDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Quantity { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public int ProductId { get; set; } = default!;
    public string ProductName { get; set; } = default!;
}
