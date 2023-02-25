using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Hubs.AddHub;
public record AddHubCommand(
    string Name,
    string Description,
    byte[]? Logo,
    string Username) : ICommand<ErrorOr<HubReadModel>>;