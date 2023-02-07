using MediatR;

namespace BusinessLogic.Application.CommandInterfaces;
public interface ICommand<TResponse> : IRequest<TResponse>
{
}