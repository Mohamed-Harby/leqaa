using BusinessLogic.Domain;
using BusinessLogic.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;

namespace BusinessLogic.Presentation.Controllers;
public class UserController : BaseController
{
    private readonly IUserRepository _userRepsitory;

    public UserController(IUserRepository userRepsitory)
    {
        _userRepsitory = userRepsitory;
    }

    [HttpGet]
    public async Task<IActionResult> Post(string name, string email, string password, string username, Gender gender)
    {
        ErrorOr<User> user = (await _userRepsitory.GetAsync(u => u.Email == email)).FirstOrDefault()!;
        if (user.Value is null)
        {
            await _userRepsitory.AddAsync(new User(name, email, password, username, gender));
            await _userRepsitory.Save();
            return Ok(user.Value);
        }
        return BadRequest(DomainErrors.User.DuplicateEmail);
    }
}