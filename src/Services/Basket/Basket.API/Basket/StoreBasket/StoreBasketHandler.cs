
namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null");
    }
}

public class StoreBasketHandler : ICommandHandler<StoreBasketCommand>
{
    public Task<Unit> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}