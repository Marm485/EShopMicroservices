﻿
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product Id is required");
    }
}

public class DeleteProductHandler (IDocumentSession session) : ICommandHandler<DeleteProductCommand>
{
    private readonly IDocumentSession _session = session;

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        _session.Delete<Product>(request.Id);

        await _session.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
