using BusinessLogic.Domain;
using BusinessLogic.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using BusinessLogic.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Presentation.Controllers;
public class RoomController : BaseController
{
    private readonly ISender _sender;
    private readonly ILogger<HubController> _logger;

    public RoomController(ISender sender, ILogger<HubController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

 
}