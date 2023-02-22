using Authentication.Application.Commands.ConfirmEmail;
using Authentication.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;







namespace MVC_BasicTutorials.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController


        public class ConfirmatinCheckController : Controller
        {
            private readonly ISender _sender;
            public ConfirmatinCheckController(ISender sender)
            {
                _sender = sender;
            }



            public async Task<IActionResult> CheckConfirmEmail([FromQuery] ConfirmEmailCommand confirmEmailRequest)
            {
                var results = await _sender.Send(confirmEmailRequest);
                if (!results.IsConfirmed)
                    return BadRequest(results);
                return View(results);
            }
            public ActionResult Index()
            {
                return View();
            }

        }
    }
}
