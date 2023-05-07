using BusinessLogic.Application.Commands.Users.SendMessage;
using BusinessLogic.Application.Models.TextChatModels.SendMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Presentation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TextChatController : BaseController
{
    private readonly ISender _sender;
    public TextChatController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessageToUser(SendMessageCommand sendMessageCommand)
    {
        var result = await _sender.Send(sendMessageCommand);
        return result.Match(
            response => Ok(response),
            errors => Problem(errors)
        );
    }
}