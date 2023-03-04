using Azure;
using BusinessLogic.Application.Commands.Channels.CreateChannel;

using BusinessLogic.Application.Commands.Posts.AddaPost;
using BusinessLogic.Application.Commands.Posts.DeletePost;
using BusinessLogic.Application.Commands.Posts.UpdatePost;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Queries.channels.ViewChannels;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Domain;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Enums;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
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
       ErrorOr<List<PostReadModel>> results = await _sender.Send(query);

        return results.Match(
          ViewPosts => Ok(ViewPosts),
          errors => Problem(errors)
      );
    }




    [HttpPut("")]
    public async Task<IActionResult> EditPost([FromQuery] Guid id, [FromBody] PostUpdateModel PostUpdateModel)
    {
        var UpdatePostCommand = new UpdatePostCommand(id, PostUpdateModel.Title, PostUpdateModel.Image, PostUpdateModel.Content);

        var results = await _sender.Send(UpdatePostCommand);

        return results.Match(
            post => Ok(post),
            errors => Problem(errors)
        );
    }

    [HttpDelete("")]
    //[HasPermission(Permission.CanDeletePost)]
    public async Task<IActionResult> RemovePost([FromQuery] Guid id)
    {

        var DeleteModel = new DeletePostCommand(id);
       var result= await _sender.Send(DeleteModel);


        return Ok(result);
    }







}




