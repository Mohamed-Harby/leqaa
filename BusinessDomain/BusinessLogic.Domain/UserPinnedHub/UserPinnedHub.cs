using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class UserPinnedHub : BaseEntity
    {
        public Guid UserPinnedid { get; set; }
        public Guid PinnedHubId { get; set; }

        public User UserPinned { get; set; } = null!;

        public Hub PinnedHub { get; set; } = null!;


    }
}

