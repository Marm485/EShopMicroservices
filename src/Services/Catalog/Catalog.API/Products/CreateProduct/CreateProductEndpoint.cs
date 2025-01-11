using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.CreateProduct;

public class CreateProductEndpoint : ICarterModule
{

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async ([FromBody] CreateProductCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return Results.Created($"/products/{result.Id}", result);
        })
            .WithName("CreateProduct")
            .Produces<CreateProductCommandResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Creates a product");
    }
}
