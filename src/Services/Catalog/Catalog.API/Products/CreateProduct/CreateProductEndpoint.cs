using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.CreateProduct;

public static class CreateProductEndpoint
{

    public static void MapCreateProductEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("/", () =>
        {
            return Results.NoContent();
        });
    }

}
