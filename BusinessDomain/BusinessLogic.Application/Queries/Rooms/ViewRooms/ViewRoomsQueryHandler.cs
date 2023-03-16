using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Rooms;
using Mapster;

namespace BusinessLogic.Application.Queries.Rooms.ViewRooms;

public class ViewRoomsQueryHandler : IHandler<ViewRoomsQuery, List<RoomReadModel>>
{
    private readonly IChannelRepository _channelRepository;

    public ViewRoomsQueryHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<List<RoomReadModel>> Handle(ViewRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = (await _channelRepository.GetAllAsync())

            .Where(c => c.Id.CompareTo(request.Cursor) > 0)
            .OrderBy(c => c.Id)
            .Take(request.Limit)
            .ToList()
            .Adapt<List<RoomReadModel>>();

        return rooms;
    }


}
