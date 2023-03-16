using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Behaviours;
public class CheckUserBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IUserNameInRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IUserRepository _userRepository;

    public CheckUserBehaviour(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault();
        if (user is null)
        {
            return (dynamic)DomainErrors.User.NotFound;
        }
        return await next();
    }
}
