using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.DeleteHub;
public record DeleteHubCommand(
     Guid hubId
) : ICommand<ErrorOr<Unit>>;