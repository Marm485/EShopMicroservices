namespace Basket.API.Basket.StoreBasket;

public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (ShoppingCart cart, ISender sender) =>
        {
            var result = await sender.Send(new StoreBasketCommand(cart));
            return Results.Created("/basket", result);
        })
        .WithName("StoreBasket")
        .Produces<StoreBasketCommandResult>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("Store a basket");
    }
}