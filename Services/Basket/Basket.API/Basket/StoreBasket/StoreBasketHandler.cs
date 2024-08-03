using Microsoft.EntityFrameworkCore;
namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCartItem SCItem) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);

//public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
//{
//    public StoreBasketCommandValidator()
//    {
//        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
//        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
//    }
//}

public class StoreBasketCommandHandler
    (DataContext dbContext)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        //await DeductDiscount(command.SCItem, cancellationToken);
        ShoppingCartItem SCItem = command.SCItem;
        dbContext.SCartItem.Add(SCItem);

        dbContext.SaveChanges();
        ShoppingCart sc = await dbContext.SCart.FirstOrDefaultAsync(i => i.UserName=="skuser") ;
        SCItem = dbContext.SCartItem.LastOrDefault();
        if (sc == null)
        {
            ShoppingCart SCart = new ShoppingCart();
            SCart.UserName = "skuser";
            SCart.Items.Add(SCItem.ProductId);
            await dbContext.SCart.AddAsync(SCart);
        }
        else
        {
            sc.Items.Add(SCItem.ProductId);
        }
        dbContext.SaveChanges();
        //await dbContext.SCart.AddAsync(command.SCItem);

        return new StoreBasketResult("skuser");
    }

    //private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    //{
    //    // Communicate with Discount.Grpc and calculate lastest prices of products into sc
    //    foreach (var item in cart.Items)
    //    {
    //        var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
    //        item.Price -= coupon.Amount;
    //    }
    //}
}
