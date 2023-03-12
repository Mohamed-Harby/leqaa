using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class UserPinnedChannel : BaseEntity
    {
        public Guid UserPinnedId { get; set; }
        public Guid PinnedChannelId { get; set; }

        public User UserPinned { get; set; } = null!;

        public Channel PinnedChannel { get; set; } = null!;


    }
}

