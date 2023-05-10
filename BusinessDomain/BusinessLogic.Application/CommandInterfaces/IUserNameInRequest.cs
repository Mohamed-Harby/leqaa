using MediatR;

namespace BusinessLogic.Application.CommandInterfaces;
public interface IUserNameInRequest<TResponse> : IRequest<TResponse>
{
    string UserName { get; }
}
