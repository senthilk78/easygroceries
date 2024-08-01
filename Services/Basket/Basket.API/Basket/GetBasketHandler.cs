using Microsoft.EntityFrameworkCore;

namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(int? Count = 1) : IQuery<GetBasketResult>;
public record GetBasketResult(IEnumerable<ShoppingCartItem> ShoppingCart);

public class GetBasketQueryHandler(DataContext dbContext)
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        if (!(dbContext.SCart.Any()))
        {
            return  new GetBasketResult(Enumerable.Empty<ShoppingCartItem>().ToList());
        }
        var basket = await dbContext.SCart.ToListAsync(cancellationToken);

        return new GetBasketResult(basket);
    }
}
