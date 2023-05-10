using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Mappings;
public class ChannelAnnouncementMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ChannelAnnouncement, ChannelAnnouncementReadModel>()
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.Title, src => src.Title)
        .Map(dest => dest.Content, src => src.Content)
        .Map(dest => dest.CreationDate, src => src.CreationDate)
        .MapToConstructor(true);
    }
}