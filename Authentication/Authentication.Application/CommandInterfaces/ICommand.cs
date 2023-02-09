using Authentication.Application.Models;
using MediatR;

namespace Authentication.Application.CommandInterfaces;
public interface ICommand : IRequest<Results>
{

}