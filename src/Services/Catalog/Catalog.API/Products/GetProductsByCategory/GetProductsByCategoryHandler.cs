using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Collections;

namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string category) : IQuery<GetProductsByCategoryResult>;

public record GetProductsByCategoryResult(IEnumerable<Product> Products);

public class GetProductsByCategoryHandler(IDocumentSession session) 
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    private readonly IDocumentSession session = session;

    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await session.Query<Product>()
                        .Where(product => product.Category.Contains(request.category))
                        .ToListAsync(cancellationToken) ?? Enumerable.Empty<Product>();

        return new GetProductsByCategoryResult(result);
    }
}
