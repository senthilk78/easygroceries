using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketRequest();
public record StoreBasketResponse(string UserName);

public class StoreBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPost("/basket/add", async (ShoppingCartItem sct, ISender sender) =>
        {
            StoreBasketCommand command = new StoreBasketCommand(sct);
            var result = await sender.Send(command);

            var response = result.Adapt<StoreBasketResponse>();

            return Results.Created($"/basket/{response.UserName}", response);
        })
        .WithName("CreateProduct")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
