namespace Basket.API.Basket.GetBasket;

public record GetBasketRequest(int? Count = 1); 
public record GetBasketResponse(IEnumerable<ShoppingCartItem> SCart);

public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/all", async ([AsParameters] GetBasketRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetBasketQuery>();
            var result = await sender.Send(query);

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}
