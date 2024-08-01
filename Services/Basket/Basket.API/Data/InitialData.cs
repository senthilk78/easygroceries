//using Marten.Schema;

using Microsoft.EntityFrameworkCore;

namespace Basket.API.Data;

public class InitialData :DbContext
{
    private DataContext DBData { get; set; }
    public InitialData(DataContext DBData)
    {
        this.DBData = DBData;
        if (!this.DBData.SCart.Any())
        {
            this.DBData.SCart.AddRange(GetPreconfiguredProducts().ToList<ShoppingCartItem>());
            this.DBData.SaveChanges();
        }
    }

    private static IEnumerable<ShoppingCartItem> GetPreconfiguredProducts() => new List<ShoppingCartItem>();

}
