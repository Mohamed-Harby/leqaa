using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Models.Users
{
    public record UserReadModel(
      Guid Id,
    string Name,
    string Email,
    string UserName,
    byte[]? ProfilePicture

);
}
