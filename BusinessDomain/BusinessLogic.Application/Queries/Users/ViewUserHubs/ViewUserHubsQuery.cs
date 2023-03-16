using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Users.ViewUserHubs;

public record ViewUserHubsQuery(
string UserName

 ) : IUserNameInQuery<ErrorOr<List<HubReadModel>>>;