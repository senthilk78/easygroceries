using Ordering.API.Dto;
using Ordering.API.Models;
using System.Collections.Generic;

namespace Ordering.API.Ordering.CreateOrder;

public record CreateOrderCommand(OrderDto order) : ICommand<CreateOrderResult>;
public record CreateOrderResult(string UserName);
public class CreateOrderHandler
    (DataContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        ShippingAddress shippingAddress = new ShippingAddress();
        shippingAddress = command.order.Address;
        await dbContext.ShippingAddress.AddAsync(command.order.Address);
        await dbContext.OrderItem.AddRangeAsync(command.order.OrderItems);

        Order order=new Order();
        order.BuyerId = command.order.BuyerId;
        order.OrderDate = command.order.OrderDate;
        order.OrderStatus = command.order.OrderStatus;
        order.Total = command.order.Total;
        order.ShippingAddressID = command.order.Address.Id;
        foreach (var item in command.order.OrderItems)
        {
            order.OrderItemIds.Add(item.Id);
        }
        await dbContext.Order.AddAsync(order);

        await dbContext.OrderItem.AddRangeAsync(command.order.OrderItems);

        dbContext.SaveChanges();

        return new CreateOrderResult(order.BuyerId);
    }

}
