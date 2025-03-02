
namespace Basket.API.Basket.StoreBasket;

public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (ShoppingCart command, ISender sender) =>
        {
            await sender.Send(new StoreBasketCommand(command));
            return Results.Created("/basket", null);
        })
        .WithName("StoreBasket")
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("Store a basket");
    }
}