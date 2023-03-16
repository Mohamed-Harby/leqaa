using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Hubs.DeployHub;
public record DeployHubCommand(
    string Name,
    string Description,
    bool IsPrivate,
    byte[]? Logo,
    string UserName) : IUserNameInCommand<ErrorOr<HubReadModel>>;
