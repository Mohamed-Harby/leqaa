using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Models.Hubs
{
  

    public record HubUpdateModel(
        Guid hubid,
        string name,
        string description
    );
}
