using BusinessLogic.Application.Commands.Channels.CreateChannel;

using BusinessLogic.Application.Commands.Posts.AddaPost;
using BusinessLogic.Application.Commands.Posts.DeletePost;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BusinessLogic.Presentation.Controllers;
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class PostController : BaseController
{
    private readonly ISender _sender;

    public PostController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> AddNewPost(PostWriteModel postWriteModel)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var addPostCommand = new AddPostCommand(
            postWriteModel.Title,
            postWriteModel.Image,
            postWriteModel.Content,
            username);

        ErrorOr<PostReadModel> result = await _sender.Send(addPostCommand);
        return result.Match(
             post => Ok(post),
             errors => Problem(errors)
         );

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePost(Guid id)
    {

        var DeleteModel = new DeletePostCommand(id);
        await _sender.Send(DeleteModel);

        return NoContent();
    }
}