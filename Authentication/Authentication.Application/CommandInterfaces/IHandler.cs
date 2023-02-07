using Authentication.Application.Models;
using MediatR;

namespace Authentication.Application.CommandInterfaces;
public interface IHandler<TRequest> : IRequestHandler<TRequest, AuthenticationResults>
    where TRequest : IRequest<AuthenticationResults>
{

}