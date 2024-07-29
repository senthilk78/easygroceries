using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Catalog.API.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public decimal Price { get; set; }
    public string Thumbnail { get; set; } = default!;
    public string Image { get; set; } = default!;
    public int Quantity { get; set; }
}
