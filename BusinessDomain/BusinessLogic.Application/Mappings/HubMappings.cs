using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.RecentActivities;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Mappings;
public class HubMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Hub, HubRecentReadModel>()
        .Map(dest => dest.HubName, src => src.Name)
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.HubDescription, src => src.Description)
        .Map(dest => dest.CreationDate, src => src.CreationDate)
        .Map(dest => dest.HubLogo, src => src.Logo)
        .MapToConstructor(true);
        
        config.NewConfig<Hub, HubReadModel>()
         .Map(dest => dest.Name, src => src.Name)
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.Description, src => src.Description)
        .Map(dest => dest.CreationDate, src => src.CreationDate)
        .Map(dest => dest.Logo, src => src.Logo)
        .MapToConstructor(true);
    }
}
