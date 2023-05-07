using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }

        public List<IDomainEvent> DomainEvents { get; set; } = new();
    }




    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<Hub>? Hubs { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Channel>? Channels { get; set; }
        public ICollection<HubAnnouncement>? HubAnnouncements { get; set; }
        public ICollection<ChannelAnnouncement>? ChannelAnnouncements { get; set; }



    }
}