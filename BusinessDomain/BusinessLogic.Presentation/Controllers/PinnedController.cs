using BusinessLogic.Application.Commands.Pin.PinHubs;
using BusinessLogic.Application.Models.Pinned.PinHubs;
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
    public async Task<IActionResult> PinHub(PinHubWriteModel PinHubWriteModel)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var PinHubCommand = new PinHubCommand(
          username,
             PinHubWriteModel.HubId

             );

        var results = await _sender.Send(PinHubCommand);
        return results.Match(
          channel => Ok(channel),
          errors => Problem(errors)
      );
    }







}