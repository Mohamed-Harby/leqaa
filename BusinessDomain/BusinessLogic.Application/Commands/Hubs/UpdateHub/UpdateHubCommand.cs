using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.UpdateHub;
public record UpdateHubCommand(
    Guid Id,
    string Name,
    string? Description,
    byte[]? logo

) : ICommand<ErrorOr<HubUpdateModel>>;