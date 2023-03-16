using BusinessLogic.Domain;
using MediatR;

namespace BusinessLogic.Application.CommandInterfaces;
public interface IQuery<TResponse> : IRequest<TResponse>
{
}
public interface IUserNameInQuery<TResponse> : IUserNameInRequest<TResponse>
{
}