namespace Basket.API.Models;

public class ShoppingCart
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; } 
    public List<int> Items { get; set; } = new();
    //public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    //Required for Mapping
    public ShoppingCart()
    {
    }
}
