using BusinessLogic.Application.Models;
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Mappings;
public class BaseEntityMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BaseEntity, BaseReadModel>()
        .Include<Hub, HubReadModel>()
        .Include<Channel, ChannelReadModel>()
        .Include<ChannelAnnouncement, ChannelAnnouncementReadModel>()
        .Include<HubAnnouncement, HubAnnouncementReadModel>()
        .Include<Post, PostReadModel>();
    }
}