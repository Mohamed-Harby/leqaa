using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.DeleteHub;
public record DeleteHubCommand(
    string Name,
    string? Description,
    Guid HubId,
    string Username
) : ICommand<ErrorOr<Hub>>;