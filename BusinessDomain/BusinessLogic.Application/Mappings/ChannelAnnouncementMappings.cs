using Mapster;

namespace BusinessLogic.Application.Mappings;
public class ChannelAnnouncementMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<AnnoucementReadModel, Announcement>()
        // .Map(dest => dest.Id, src => src.Id)
        // .Map(dest => dest.Title, src => src.Title)
        // .Map(dest => dest.Content, src => src.Content)
        // .Map(dest => dest.CreationDate, src => src.CreationDate)
        // .MapToConstructor(true);
    }
}