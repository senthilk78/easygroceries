using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Catalog.API.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public double Price { get; set; }
    public string pictureUrl { get; set; } = default!;
    public string Image { get; set; } = default!;
    public int Quantity { get; set; }
}
