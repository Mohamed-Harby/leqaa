using BusinessLogic.Domain;
using BusinessLogic.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Presentation.Controllers;
public class UserController : BaseController
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {

        _sender = sender;
    }

    
}