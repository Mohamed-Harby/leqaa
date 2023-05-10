using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Models.RecentActivities;

public record ChannelRecentAnnouncementReadModel(
    string Title,
    string? Content,
    byte[]? Image,
    string UserName,
    Guid ChannelId,
    Guid Id,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);