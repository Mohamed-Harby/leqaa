using BusinessLogic.Application.CommandInterfaces;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.TransactionalCommands;
public record SaveChangesCommand() : ICommand<ErrorOr<int>>;