using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Models.Rooms
{
    public record RoomReadModel(
    Guid Id,
    string name,
    string description

);
}
