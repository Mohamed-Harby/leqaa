using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Channels.GetChannelMembers
{
    public record GetChannelMembersQuery(
        Guid ChannelId
        ):IQuery<ErrorOr<List<UserReadModel>>>;
}
