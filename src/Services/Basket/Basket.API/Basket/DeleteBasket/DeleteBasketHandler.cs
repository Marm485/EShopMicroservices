namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class DeleteBasketHandler
    (IBasketRepository basketRepository) 
    : ICommandHandler<DeleteBasketCommand>
{
    public async Task<Unit> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        await basketRepository.DeleteBasketAsync(request.UserName, cancellationToken)
            .ConfigureAwait(false);

        return Unit.Value;
    }
}