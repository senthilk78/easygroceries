using Ordering.API.Dto;
using Ordering.API.Models;

namespace Ordering.API.Ordering.CreateOrder;

//public record AddShippingAddressRequest();
//public record AddShippingAddressResponse(string UserName);
public record CreateOrderRequest();
public record CreateOrderResponse(string UserName);
public class CreateOrderEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/order/add", async (OrderDto order, ISender sender) =>
        {
            CreateOrderCommand command = new CreateOrderCommand(order);
            var result = await sender.Send(command);

            var response = result.Adapt<CreateOrderResponse>();

            return Results.Created($"/order/{response.UserName}", response);
        })
        .WithName("Order")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create order")
        .WithDescription("Create order");
    }

}
