using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Users;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Hubs.viewHubUsers
{
    public record ViewHubUsersQuery
   (
        Guid hubid

       ) : IQuery<ErrorOr<List<UserRecentReadModel>>>;
}