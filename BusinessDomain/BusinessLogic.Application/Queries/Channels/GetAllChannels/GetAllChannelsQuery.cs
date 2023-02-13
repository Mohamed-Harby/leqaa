using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using MediatR;

namespace BusinessLogic.Application.Queries.Hubs.GetAllHubs;
public record GetAllChannelsQuery() : IQuery<List<ChannelReadModel>>;