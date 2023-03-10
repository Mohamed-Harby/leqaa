using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Models.Annoucements.HubAnnoucements
{
    public record HubAnnoucementWriteModel(
    string Title,
     string? Content,

      byte[]? Image,

      Guid HubId

        );
}
