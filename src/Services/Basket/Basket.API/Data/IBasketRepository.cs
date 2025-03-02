using Basket.API.Basket.GetBasket;

namespace Basket.API.Data;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default);
    Task StoreBasketAsync(ShoppingCart cart, CancellationToken cancellationToken = default);
    Task DeleteBasketAsync(string userName, CancellationToken cancellationToken = default);
}