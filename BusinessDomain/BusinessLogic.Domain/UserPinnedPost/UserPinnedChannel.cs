using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public class UserPinnedPost: BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PinnedPostId { get; set; }

        public User UserPinned { get; set; } = null!;

        public PinnedPost PinnedPost { get; set; } = null!;


    }
}

