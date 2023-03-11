using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Models.Annoucements.HubAnnoucements
{
    public record HubAnnouncementReadModel(
        string Title,
        string? Content,
        byte[]? Image,
        string UserName,
        Guid HubId,
        Guid Id,
        DateTime CreationDate) : BaseReadModel(Id, CreationDate);
}