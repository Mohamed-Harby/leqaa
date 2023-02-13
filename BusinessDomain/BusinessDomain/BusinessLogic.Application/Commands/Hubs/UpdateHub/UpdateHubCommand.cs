using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.UpdateHub;
public record UpdateHubCommand(
    string Name,
    string? Description,
    Guid HubId,
    string Username
) : ICommand<ErrorOr<Hub>>;