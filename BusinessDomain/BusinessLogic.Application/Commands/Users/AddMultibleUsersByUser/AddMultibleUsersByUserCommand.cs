using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Users.AddMultibleUsersByUser;



    public record AddMultibleUsersByUserCommand(
        string UserName,
       List<string> AddedUserNames,
  
        Guid? HubId
        ) : IUserNameInCommand<ErrorOr<List<UserReadModel>>>;

