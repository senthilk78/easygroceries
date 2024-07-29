using Catalog.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler
    (DataContext dbContext)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await dbContext.Products
                       .Skip((query.PageNumber ?? 1)-1 * query.PageSize ?? 10)
                       .Take(query.PageSize ?? 10)
                       .ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}
