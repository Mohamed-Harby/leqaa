using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Plans;
using BusinessLogic.Application.Models.Users;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Users.AddUserByUser
{


    public record AddUserByUserCommand(
        string UserName,
        string addedUser,
        Guid? hupId,
        Guid? channelId) : IUserNameInCommand<ErrorOr<UserReadModel>>;
}
