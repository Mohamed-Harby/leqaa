using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Channels.ViewChannel;
public record ViewChannelQuery(
    Guid Id
) : IQuery<ErrorOr<ChannelReadModel>>;