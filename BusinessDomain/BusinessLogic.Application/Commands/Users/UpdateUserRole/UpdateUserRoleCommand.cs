using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Domain.SharedEnums;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Users.UpdateUserRole
{
  public record UpdateUserRoleCommand(
      string userNameAdding,
      string userNameToUpdate,
      GroupRole NewRole) : ICommand<ErrorOr<Unit>>;
}
