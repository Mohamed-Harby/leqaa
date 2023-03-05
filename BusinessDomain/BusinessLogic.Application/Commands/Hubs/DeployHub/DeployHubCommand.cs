using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Hubs.DeployHub;
public record DeployHubCommand(
    string Name,
    string Description,
    bool IsPrivate,
    byte[]? Logo,
    string Username) : ICommand<ErrorOr<HubReadModel>>;