
namespace Catalog.API.Products.GetProductById;

public class GetProductByIdEnpoint() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid Id, ISender _sender) =>
        {
            var query = new GetProductByIdQuery(Id);

            try
            {
                var result = await _sender.Send(query);
                return Results.Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return Results.NotFound();
            }
        })
            .WithName(nameof(GetProductByIdEnpoint))
            .Produces<GetProductByIdResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
