using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedChannel
{
  public record DeletePinnedChannelCommand(
      string userName,
      Guid ChannelId

      ) : ICommand<ErrorOr<ChannelReadModel>>;
}
