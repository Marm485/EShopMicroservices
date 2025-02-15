
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProducts;

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (
            ISender sender,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            ) =>
        {
            var query = new GetProductsQuery(pageNumber, pageSize);

            var result = await sender.Send(query);

            return Results.Ok(result);
        })
            .WithName("GetProducts")
            .Produces(StatusCodes.Status200OK, typeof(GetProductsResult));
    }
}
