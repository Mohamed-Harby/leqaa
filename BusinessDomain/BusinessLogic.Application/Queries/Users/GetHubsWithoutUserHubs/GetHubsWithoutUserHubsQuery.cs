using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Users;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Hubs.GetHubsWithoutUserHubs
{
    public record GetHubsWithoutUserHubsQuery
    (
        string UserName
        
    ) : IUserNameInQuery<ErrorOr<List<HubReadModel>>>;
}