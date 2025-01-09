using MediatR;

namespace BuildingBlocks.CQRS;


// Unit means void for MediatR, it is used because void is not valid in 
public interface ICommand : ICommand<Unit> { }

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
