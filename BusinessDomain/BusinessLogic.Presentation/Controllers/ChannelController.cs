using BusinessLogic.Application.Commands.Channels.AddChannel;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Presentation.Controllers;
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ChannelController : BaseController
{
    private readonly ISender _sender;

    public ChannelController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> Post(ChannelWriteModel channelWriteModel, string username)
    {
        var addChannelCommand = new AddChannelCommand(
            channelWriteModel.name,
            channelWriteModel.description,
            channelWriteModel.hubId,
            username);

        ErrorOr<Channel> result = await _sender.Send(addChannelCommand);
        return result.Match(
             channel => Ok(channelWriteModel),//TODO
             errors => Problem(errors)
         );

    }

 /*   [HttpDelete]
    public async */



}