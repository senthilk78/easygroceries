using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketRequest();
public record StoreBasketResponse(string UserName);

public class StoreBasketEndpoints : ICarterModule
{
    //public void AddRoutes(IEndpointRouteBuilder app)
    //{
    //    app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
    //    {
    //        var command = request.Adapt<StoreBasketCommand>();

    //        var result = await sender.Send(command);

    //        var response = result.Adapt<StoreBasketResponse>();

    //        return Results.Created($"/basket/{response.UserName}", response);
    //    })
    //    .WithName("CreateProduct")
    //    .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
    //    .ProducesProblem(StatusCodes.Status400BadRequest)
    //    .WithSummary("Create Product")
    //    .WithDescription("Create Product");
    //}
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        //app.MapPost("/basket/{ProductID}/{Quantity}", async (int ProductID, int Quantity, ISender sender) =>
        //{
        //    ShoppingCartItem sct = new ShoppingCartItem();
        //    sct.ProductId = ProductID;
        //    sct.Quantity = Quantity;
        //    //var command = new StoreBasketCommand(sct);
        //    StoreBasketCommand command = new StoreBasketCommand(sct);
        //    var result = await sender.Send(command);

        //    var response = result.Adapt<StoreBasketResponse>();

        //    return Results.Created($"/basket/{response.UserName}", response);
        //})
        //.WithName("CreateProduct")
        //.Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        //.ProducesProblem(StatusCodes.Status400BadRequest)
        //.WithSummary("Create Product")
        //.WithDescription("Create Product");

        app.MapPost("/basket/add", async (ShoppingCartItem sct, ISender sender) =>
        {
            //var command = sct.Adapt<StoreBasketCommand>();
            //var command = new StoreBasketCommand(sct);
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
