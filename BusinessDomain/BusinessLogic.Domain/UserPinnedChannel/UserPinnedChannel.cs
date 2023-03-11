using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class UserPinnedChannel : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PinnedChannelId { get; set; }

        public User User { get; set; } = null!;

        public PinnedChannel PinnedChannel { get; set; } = null!;


    }
}

