using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using BusinessLogic.Application.Models.Posts;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Annoucements.HubAnnoucements
{
    public record DeployHubAnnoucementCommand(


          string Title,
      string? Content,
        byte[]? Image,

       Guid HubId,
           string UserName
        ) : ICommand<ErrorOr<HubAnnouncementReadModel>>;
}
