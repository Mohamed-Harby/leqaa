using Authentication.Application.Models;
using MediatR;

namespace Authentication.Application.CommandInterfaces;
public interface IQuery : IRequest<AuthenticationResults>
{

}