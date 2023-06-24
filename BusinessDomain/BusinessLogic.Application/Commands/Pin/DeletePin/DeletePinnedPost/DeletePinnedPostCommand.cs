using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Posts;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedPost
{
  public record DeletePinnedPostCommand(
      string userName,
      Guid PostId

      ) : ICommand<ErrorOr<PostReadModel>>;
}
