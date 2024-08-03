using Microsoft.EntityFrameworkCore;
using Basket.API.Basket.Dto;
using System.Collections.Generic;

namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string userName) : IQuery<GetBasketResult>;
public record GetBasketResult(BasketDto ShoppingCart);

public class GetBasketQueryHandler(DataContext dbContext)
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        if (!(dbContext.SCart.Any()))
        {
            return new GetBasketResult(new BasketDto());
        }
        ShoppingCart SCart= await dbContext.SCart.FirstOrDefaultAsync(SCart => SCart.UserName == query.userName);

        //var basket = await dbContext.SCart.ToListAsync(cancellationToken);
        BasketDto basket = new BasketDto();
        basket.buyerId = query.userName;
        basket.Id = 1;
        foreach(int Id in SCart.Items)
        {
            basket.Items.Add(await dbContext.SCartItem.FirstOrDefaultAsync(SCartItem => SCartItem.ProductId==Id));
        }

        return new GetBasketResult(basket);
    }
    //public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    //{
    //    if (!(dbContext.SCart.Any()))
    //    {
    //        return  new GetBasketResult(Enumerable.Empty<ShoppingCart>().ToList());
    //    }
    //    var basket = await dbContext.SCart.ToListAsync(cancellationToken);

    //    return new GetBasketResult(basket);
    //}
}
