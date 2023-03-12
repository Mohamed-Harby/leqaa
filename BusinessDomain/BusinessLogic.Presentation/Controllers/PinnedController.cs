using BusinessLogic.Application.Commands.Pin.PinChannels;
using BusinessLogic.Application.Commands.Pin.PinHubs;
using BusinessLogic.Application.Commands.Pin.PinPosts;
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
public class PinnedController : BaseController
{
    private readonly ISender _sender;
    public PinnedController(ISender sender)
    {
        _sender = sender;
    }














    [HttpPost]
    public async Task<IActionResult> PinHub( Guid HubId)
    { 
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var PinHubCommand = new PinHubCommand(
          username,
          HubId

             );

        var results = await _sender.Send(PinHubCommand);
        return results.Match(
          channel => Ok(channel),
          errors => Problem(errors)
      );
    }




    [HttpPost]
    public async Task<IActionResult> PinPost(Guid PostID)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var PinHubCommand = new PinPostCommand(
          username,
          PostID

             );

        var results = await _sender.Send(PinHubCommand);
        return results.Match(
          channel => Ok(channel),
          errors => Problem(errors)
      );
    }
    [HttpPost]
    public async Task<IActionResult> PinChannel(Guid channelId)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var PinChannelCommand = new PinChannelCommand(
          username,
          channelId

             );

        var results = await _sender.Send(PinChannelCommand);
        return results.Match(
          channel => Ok(channel),
          errors => Problem(errors)
      );
    }



}