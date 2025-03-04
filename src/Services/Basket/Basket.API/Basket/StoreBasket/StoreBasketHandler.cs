namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketCommandResult>;

public record StoreBasketCommandResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null");
    }
}

public class StoreBasketHandler
    (IBasketRepository basketRepository)
    : ICommandHandler<StoreBasketCommand, StoreBasketCommandResult>
{
    public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        await basketRepository.StoreBasketAsync(request.Cart, cancellationToken)
            .ConfigureAwait(false);

        return new StoreBasketCommandResult(request.Cart.UserName);
    }
}