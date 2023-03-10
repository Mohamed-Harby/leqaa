using BusinessLogic.Application.Commands.Annoucements.ChannnelAnnoucement.AddChannelAnnoucement;
using BusinessLogic.Application.Commands.Annoucements.HubAnnoucements;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using BusinessLogic.Application.Models.Channels;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Presentation.Controllers;
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class AnnoucementController : BaseController
{
    private readonly ISender _sender;
    public AnnoucementController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> DeployHubAnnoucement(HubAnnoucementWriteModel hupAnnouncementWriewModel)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var addHubAnnoucementCommand = new DeployHubAnnoucementCommand(
            hupAnnouncementWriewModel.Title,
            hupAnnouncementWriewModel.Content,
            hupAnnouncementWriewModel.Image,
             hupAnnouncementWriewModel.HubId,
            username
             );

        var results = await _sender.Send(addHubAnnoucementCommand);
        return results.Match(
          channel => Ok(channel),
          errors => Problem(errors)
      );
    }





    [HttpPost]
    public async Task<IActionResult> DeployChannelAnnoucement(ChannelAnnoucementWriteModel channelAnnouncementWriewModel)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var addHubAnnoucementCommand = new DeployChannelAnnoucementCommand(
            channelAnnouncementWriewModel.Title,
            channelAnnouncementWriewModel.Content,
            channelAnnouncementWriewModel.Image,
             channelAnnouncementWriewModel.ChannelId,
            username
             );

        var results = await _sender.Send(addHubAnnoucementCommand);
        return results.Match(
          channel => Ok(channel),
          errors => Problem(errors)
      );




    }
  


}