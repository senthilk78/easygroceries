﻿namespace Basket.API.Models;

public class ShoppingCartItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Quantity { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public int ProductId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string pictureUrl { get; set; } = default!;
}
