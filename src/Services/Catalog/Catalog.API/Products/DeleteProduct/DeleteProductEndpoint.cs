
namespace Catalog.API.Products.DeleteProduct;

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid Id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteProductCommand(Id));

                return Results.NoContent();
            }
            catch (ProductNotFoundException)
            {
                return Results.NotFound();
            }
            
        })
            .WithName("DeleteProduct")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
