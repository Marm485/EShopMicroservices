
namespace Basket.API.Data;

public class BasketRepository
    (IDocumentSession documentSession) : IBasketRepository
{
    public async Task DeleteBasketAsync(string userName, CancellationToken cancellationToken = default)
    {
        documentSession.Delete(userName);
        await documentSession.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
    {
        var basket = await documentSession.LoadAsync<ShoppingCart>(userName, cancellationToken).ConfigureAwait(false);
        
        return basket is null ? throw new BasketNotFoundException(userName) : basket;
    }

    public async Task StoreBasketAsync(ShoppingCart cart, CancellationToken cancellationToken = default)
    {
        documentSession.Store(cart);

        await documentSession.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}