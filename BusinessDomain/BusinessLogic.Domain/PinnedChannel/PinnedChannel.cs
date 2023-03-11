using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    
    public class PinnedChannel : BaseEntity
    {

        public Guid UserPinnedChannelId { get; set; } = Guid.Empty;
        public User UserPinned { get; set; } = null!;
     
        public virtual ICollection<Channel> Channels { get; private set; }

        public void AddChannel(Channel channel)
        {
            Channels.Add(channel);
        }
    

    }
}
