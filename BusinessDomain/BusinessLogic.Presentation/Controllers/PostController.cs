
using BusinessLogic.Application.Commands.Posts.AddPost;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Post(PostWriteModel postWriteModel, string username)
    {
        var addPostCommand = new AddPostCommand(
            postWriteModel.name,
            postWriteModel.description,
           postWriteModel.hubId,
           postWriteModel.channelId,

            username);

        ErrorOr<Post> result = await _sender.Send(addPostCommand);
        return result.Match(
             post => Ok(postWriteModel),//TODO : change this later
             errors => Problem(errors)
         );

    }
}