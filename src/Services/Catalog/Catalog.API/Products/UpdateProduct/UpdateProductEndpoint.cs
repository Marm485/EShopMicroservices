
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products/{id}", async (Guid Id, [FromBody] UpdateProductRequest request, ISender sender) =>
        {
            try
            {
                var result = await sender.Send(
                    new UpdateProductCommand(
                        Id,
                        request.Name,
                        request.Category,
                        request.Description,
                        request.ImageFile,
                        request.Price));

                return Results.Ok(result);
            }
            catch (ProductNotFoundException)
            {
                return Results.NotFound();
            }
        })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
