using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedHub
{
  public record DeletePinnedHubCommand(
      string userName,
      Guid HubId

      ) : ICommand<ErrorOr<HubReadModel>>;
}
