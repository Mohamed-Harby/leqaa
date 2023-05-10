using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.JoinHub;
public record JoinHubCommand(
    string UserName,
    Guid HubId
) : ICommand<ErrorOr<HubReadModel>>;