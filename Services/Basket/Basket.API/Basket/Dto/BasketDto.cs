namespace Basket.API.Basket.Dto;
public class BasketDto
{
    public int Id { get; set; }
    public string buyerId { get; set; }
    public List<ShoppingCartItem> Items { get; set; } = new();

}