using Basket.API.Data;

namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCart Cart);

public class GetBasketHandler
    (IBasketRepository basketRepository)
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var cart = await basketRepository.GetBasketAsync(request.UserName, cancellationToken)
            .ConfigureAwait(false);

        return new GetBasketResult(cart);
    }
}