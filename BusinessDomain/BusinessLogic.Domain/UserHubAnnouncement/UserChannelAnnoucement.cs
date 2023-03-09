using BusinessLogic.Domain.SharedEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class UserChannelAnnoucement : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ChannelId { get; set; }
        public User User { get; set; } = null!;
        public Channel channel { get; set; } = null!;
        public GroupRole Role { get; set; } = GroupRole.Member;

    }
}
