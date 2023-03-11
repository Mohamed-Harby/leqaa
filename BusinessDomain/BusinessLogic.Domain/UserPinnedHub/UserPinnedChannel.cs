using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class UserPinnedHub : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PinnedHubId { get; set; }

        public User UserPinned { get; set; } = null!;

        public PinnedHub PinnedChannel { get; set; } = null!;


    }
}

