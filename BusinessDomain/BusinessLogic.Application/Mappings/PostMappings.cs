using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Mappings;
public class PostMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Post, PostReadModel>()
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.PostTitle, src => src.Title)
        .Map(dest => dest.PostContent, src => src.Content)
        .Map(dest => dest.PostImage, src => src.Image)
        .Map(dest => dest.CreationDate, src => src.CreationDate)
        .MapToConstructor(true);
    }
}
