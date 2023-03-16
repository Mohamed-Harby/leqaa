using BusinessLogic.Domain.SharedEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain;
public class UserHubAnnouncement : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid HubAnnouncementId { get; set; }

    public User User { get; set; } = null!;

    public HubAnnouncement HubAnnouncement { get; set; } = null!;


}