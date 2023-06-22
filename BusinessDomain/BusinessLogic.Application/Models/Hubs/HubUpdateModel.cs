using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Models.Hubs
{
  

    public record HubUpdateModel(
        Guid id,
        string name,
        string description,
        byte[]? logo
    );
}
