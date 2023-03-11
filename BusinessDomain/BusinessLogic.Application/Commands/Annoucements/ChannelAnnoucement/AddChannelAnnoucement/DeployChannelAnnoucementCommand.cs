using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;

using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Annoucements.ChannnelAnnoucement.AddChannelAnnoucement;


public record DeployChannelAnnoucementCommand(


      string Title,
  string? Content,
    byte[]? Image,

   Guid ChannelId,
       string UserName
    ) : ICommand<ErrorOr<ChannelAnnouncementReadModel>>;

