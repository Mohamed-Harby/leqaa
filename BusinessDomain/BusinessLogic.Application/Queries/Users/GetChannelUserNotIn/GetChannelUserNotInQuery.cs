using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Queries.Users.GetChannelUserNotIn;


public record GetChannelUserNotInQuery (
    
    string userName
    
    ) : IQuery<ErrorOr<List<ChannelReadModel>>>;