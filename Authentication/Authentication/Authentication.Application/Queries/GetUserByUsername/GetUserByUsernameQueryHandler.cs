using Authentication.Application.CommandInterfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Queries.GetUserByUsername;
public class GetUserByUsernameQueryHandler : IHandler<GetUserByUsername>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public GetUserByUsernameQueryHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Results> Handle(GetUserByUsername request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        return new Results
        {
            User = user.Adapt<UserReadModel>(),
            IsSuccess = true
        };
    }
}
