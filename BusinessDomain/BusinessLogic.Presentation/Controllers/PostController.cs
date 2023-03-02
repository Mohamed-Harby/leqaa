using Azure;
using BusinessLogic.Application.Commands.Channels.CreateChannel;

using BusinessLogic.Application.Commands.Posts.AddaPost;
using BusinessLogic.Application.Commands.Posts.DeletePost;
using BusinessLogic.Application.Commands.Posts.UpdatePost;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Queries.channels.ViewChannels;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Domain;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Enums;
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

        ErrorOr<PostWriteModel> result = await _sender.Send(addPostCommand);
        return result.Match(
             post => Ok(post),
             errors => Problem(errors)
         );

    }



    [HttpGet]
    public async Task<IActionResult> ViewPosts([FromQuery] int pageNumber,int pageSize)
    {
        var query = new GetAllPostsQuery(pageNumber,pageSize);
        var posts = await _sender.Send(query);

        return Ok(posts);
    }

    [HttpDelete("{id}")]
    //[HasPermission(Permission.CanDeletePost)]
    public async Task<IActionResult> RemovePost(Guid id)
    {

        var DeleteModel = new DeletePostCommand(id);
        await _sender.Send(DeleteModel);

        return NoContent();
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(Guid id, UpdatePostCommand command)
    {
        if (id != command.GuidpostId)
        {
            return BadRequest();
        }

        await _sender.Send(command);

        return NoContent();
    }
}




