using MediatR;

namespace BusinessLogic.Application.CommandInterfaces;
public interface IHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
where TRequest : IRequest<TResponse>
{

}
