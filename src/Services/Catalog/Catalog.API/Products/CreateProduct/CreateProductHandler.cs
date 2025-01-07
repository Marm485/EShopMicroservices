using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : IRequest<CreateProductCommandResult>;

public record CreateProductCommandResult(Guid Id);

internal class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
{
    public Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
