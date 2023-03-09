using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Models.Annoucements.HubAnnoucements
{
    public record HubAnnoucementReadModel(
        Guid Id,
    string Title,
     string? Content,

      byte[]? Image,

    Guid UserName,
      Guid HupId,
      DateTime CreationDate

        ) : BaseReadModel(Id, CreationDate);
}