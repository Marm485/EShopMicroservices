namespace Basket.API.Basket.GetBasket;

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var response = await sender.Send(new GetBasketQuery(userName));
            return response is null ? Results.NotFound() : Results.Ok(response);
        })
        .WithName("GetBasketByUserName")
        .Produces<GetBasketResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithDescription("Get a basket by user name");
    }
}