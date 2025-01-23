
namespace Catalog.API.Products.GetProducts;

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = new GetProductsQuery();

            var result = await sender.Send(query);

            return Results.Ok(result);
        })
            .WithName("GetProducts")
            .Produces(StatusCodes.Status200OK, typeof(GetProductsResult));
    }
}
