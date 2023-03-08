using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Mappings;
public class HubMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Hub, HubReadModel>()
        .Map(dest => dest.HubName, src => src.Name)
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.HubDescription, src => src.Description)
        .Map(dest => dest.CreationDate, src => src.CreationDate)
        .Map(dest => dest.HubLogo, src => src.Logo)
        .MapToConstructor(true);
    }
}
