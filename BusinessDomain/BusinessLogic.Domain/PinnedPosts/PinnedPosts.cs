using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{

    public class PinnedPost : BaseEntity
    {

        public Guid UserPinnedChannelId { get; set; } = Guid.Empty;
        public User UserPinned { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; private set; }








    }
}
