using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.RecentActivities;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Mappings;
public class ChannelMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Channel, ChannelRecentReadModel>()
        .Map(dest => dest.ChannelName, src => src.Name)
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.ChannelDescription, src => src.Description)
        .Map(dest => dest.CreationDate, src => src.CreationDate)
        .Map(dest => dest.ChannelImage, src => src.Image).MapToConstructor(true);
    }
}