using Authentication.Application.Models;
using MediatR;

namespace Authentication.Application.CommandInterfaces;
public interface IHandler<TRequest> : IRequestHandler<TRequest, Results>
    where TRequest : IRequest<Results>
{

}