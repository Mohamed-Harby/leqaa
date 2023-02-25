using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;

namespace BusinessLogic.Application.Queries.channels.ViewChannels;
public record ViewRoomQuery(
 int Limit ,
 string Cursor 
    
    ) : IQuery<List<ChannelReadModel>>;