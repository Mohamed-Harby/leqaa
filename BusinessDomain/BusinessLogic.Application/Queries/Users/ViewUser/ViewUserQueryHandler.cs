using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Users.ViewUser;
public class ViewUserQueryHandler : IHandler<ViewUserQuery, ErrorOr<UserReadModel>>
{
    private readonly IUserRepository _userRepository;

    public ViewUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserReadModel>> Handle(ViewUserQuery request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault();
        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }
        return user.Adapt<UserReadModel>();
    }
}
