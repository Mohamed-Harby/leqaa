using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Users.LeaveHub
{
    public record LeaveHubCommand(
     string UserName,
     Guid HubId
 ) : ICommand<ErrorOr<HubReadModel>>;
}
