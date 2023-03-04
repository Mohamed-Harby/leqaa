using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;

namespace BusinessLogic.Application.Queries.channels.ViewChannels;
public record ViewChannelsQuery(

 int PageNumber,
int PageSize

    ) : IQuery<List<ChannelReadModel>>;