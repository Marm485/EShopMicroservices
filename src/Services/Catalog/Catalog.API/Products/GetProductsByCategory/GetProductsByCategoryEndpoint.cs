
namespace Catalog.API.Products.GetProductsByCategory;

public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsByCategoryQuery(category));

            if (result.Products.Any())
            {
                return Results.Ok(result);
            }

            return Results.NotFound();
        })
            .WithName("GetProductsByCategory")
            .Produces<GetProductsByCategoryResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
